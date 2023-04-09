//async function loadUserDetails() {
//    await setDetails();
//    setRate();
//}

//async function setDetails(){

//    const userJson = sessionStorage.getItem('user');
//    const user = JSON.parse(userJson);
//    const id = user.id;
//    const email = user.email;
//    const password = user.password.replace(/\s+/g, '');
//    const firstName = user.firstName;
//    const lastName = user.lastName;

//    document.getElementById("email").value = email;
//    document.getElementById("userPassword").value = password;
//    document.getElementById("firstName").value = firstName;
//    document.getElementById("lastName").value = lastName;

//    const welcome = `Hello ${firstName}  ${lastName}`;

//    document.getElementById("heading").innerHTML = welcome;

//}


//async function update() {
//    const userJson = sessionStorage.getItem('user');
//    const user = JSON.parse(userJson);
//    const id = user.id;
//    const email = document.getElementById("email").value;
//    const password = document.getElementById("userPassword").value;
//    const firstName = document.getElementById("firstName").value;
//    const lastName = document.getElementById("lastName").value;

//    const strength = await passwordRate(password);
//    if (strength < 2) {
//        alert('password too weak');
//    }
//    else {
//        const dataToSent = {
//            Id: id,
//            Email: email,
//            Password: password,
//            FirstName: firstName,
//            LastName: lastName
//        }

//        const res = await fetch(`api/users/${id}`,
//            {
//                method: 'PUT',
//                headers: {
//                    'Content-Type': 'application/json'
//                },
//                body: JSON.stringify(dataToSent)
//            }
//        )
//        const status = res.status;
//        if (status == 200) {
//            alert(`User details have been updated,You are taken to the login page`);
//            //change the view of first and last name? or -
//            window.location.assign("./home.html");
//        }
//        else {
//            alert(`one or more details aren't valid. res.status = ${status}`);
//        }
//    }
//}

//function showUpdate() {
//    const updateDiv = document.querySelector('.update');
//    updateDiv.style.display = 'block';

//    const toUpdateA = document.getElementById('toUpdate');
//    toUpdateA.style.display = 'none';
//}


//async function setRate() {
//    const password = document.getElementById("userPassword").value;
//    const strenghRate = await passwordRate(password);
//    const progress = document.getElementById("strengh-rate");
//    progress.value = strenghRate;
//}

//async function passwordRate(password){
//    const result = await fetch("api/password",
//        {
//            method: 'POST',
//            headers: {
//                'Content-Type': 'application/json'
//            },

//            body: JSON.stringify(password)
//        }
//    );
//    const strenghRate = await result.json();
//    return strenghRate;
//}

async function loadUserDetails() {
    try {
        const user = JSON.parse(sessionStorage.getItem('user'));
        const { id, email, password, firstName, lastName } = user;
        document.getElementById("email").value = email;
        document.getElementById("userPassword").value = password.replace(/\s+/g, '');
        document.getElementById("firstName").value = firstName;
        document.getElementById("lastName").value = lastName;
        document.getElementById("heading").innerHTML = `Hello ${firstName} ${lastName}`;
        await setRate();
    } catch (error) {
        console.error(error);
        alert('Error loading user details.');
    }
}

async function update() {
    const user = JSON.parse(sessionStorage.getItem('user'));
    const { id } = user;
    const email = document.getElementById("email").value;
    const password = document.getElementById("userPassword").value;
    const firstName = document.getElementById("firstName").value;
    const lastName = document.getElementById("lastName").value;

    const strength = await passwordRate(password);
    if (strength < 2) {
        alert('Password too weak');
        return;
    }

    const dataToSend = { id, email, password, firstName, lastName };
    const res = await fetch(`api/users/${id}`, {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(dataToSend)
    });
    const status = res.status;

    if (status === 200) {
        alert('User details have been updated. You will be taken to the login page.');
        window.location.assign('./home.html');
    } else {
        alert(`One or more details aren't valid. Response status: ${status}`);
    }
}

function showUpdate() {
    const updateDiv = document.querySelector('.update');
    const toUpdateA = document.getElementById('toUpdate');
    updateDiv.style.display = 'block';
    toUpdateA.style.display = 'none';
}

async function setRate() {
    const password = document.getElementById("userPassword").value;
    const strengthRate = await passwordRate(password);
    const progress = document.getElementById("strengh-rate");
    progress.value = strengthRate;
}

async function passwordRate(password) {
    const res = await fetch('api/password', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(password)
    });
    const strengthRate = await res.json();
    return strengthRate;
}

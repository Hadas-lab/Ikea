async function loadUserDetails() {

    const userJson = sessionStorage.getItem('user');
    const user = JSON.parse(userJson);
    const id = user.id;
    const email = user.email;
    const password = user.password;
    const firstName = user.firstName;
    const lastName = user.lastName;

    document.getElementById("email").value = email;
    document.getElementById("userPassword").value = password;
    document.getElementById("firstName").value = firstName;
    document.getElementById("lastName").value = lastName;

    const welcome = `Hello ${firstName}  ${lastName}`;

    document.getElementById("heading").innerHTML = welcome;

}


async function update() {
    const userJson = sessionStorage.getItem('user');
    const user = JSON.parse(userJson);
    const id = user.id;
    const email = document.getElementById("email").value;
    const password = document.getElementById("userPassword").value;
    const firstName = document.getElementById("firstName").value;
    const lastName = document.getElementById("lastName").value;


    const dataToSent = {
        Id: id,
        Email: email,
        Password: password,
        FirstName: firstName,
        LastName: lastName
    }

    const res = await fetch(`api/users/${id}`,
        {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(dataToSent)
        }
    )
    const status = res.status;
    if (status == 200) {
        alert(`user updated successfully. res.status = ${status}`);
    }
    else {
        alert(`one or more details aren't valid. res.status = ${status}`);
    }
}


function showUpdate() {
    var updateDiv = document.querySelector('.update');
    updateDiv.style.display = 'block';

    var toUpdateA = document.getElementById('toUpdate');
    toUpdateA.style.display = 'none';

    
}


async function setRate() {
    const password = document.getElementById("userPassword").value;
    const result = await fetch("api/password",
        {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },

            body: JSON.stringify(password)
        }
    );
    const strenghRate = await result.json();
    var progress = document.getElementById("strengh-rate");
    progress.value = strenghRate;

}
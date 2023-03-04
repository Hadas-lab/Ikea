async function signUp() {

    const email = document.getElementById("new-email").value;
    const password = document.getElementById("new-password").value;
    const firstName = document.getElementById("first-name").value;
    const lastName = document.getElementById("last-name").value;

    const dataToSent = {
        Email: email,
        Password: password,
        FirstName: firstName,
        LastName: lastName
    }
    const res = await fetch("api/user",
        {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(dataToSent)
        }
    )

    const status = res.status;
    if (status == 200) {
        alert('user signed up successfully');
    }
    else if (status == 601) {
        alert(`Password too weak. Please choose a stronger password. res.status = ${status}`);
    }
    else if (status == 602) {
        alert(`Password is on a blacklist. Please choose a different password. res.status = ${status}`);
    }
    else {
        alert(`one or more details aren't valid res.status = ${status}`);
    }
}


async function signIn() {
    const email = document.getElementById("email").value;
    const password = document.getElementById("password").value;
    const dataToSent = {
        "Email": email,
        "Password": password
    }
    const res = await fetch("api/user/signIn",
        {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(dataToSent)
        }
    )
    if (res.status == 204) {
        alert('user name or password are incorrect');
    }
    else {
        const user = await res.json();
        sessionStorage.setItem("user", JSON.stringify(user));
        window.location.assign("./UserDetails.html");    
    }
}


function showSignUp() {
    var signInDiv = document.querySelector('.signin');
    var signUpDiv = document.querySelector('.signup');
    signInDiv.style.display = 'none';
    signUpDiv.style.display = 'block';
}

function showSignIn(){
    var signInDiv = document.querySelector('.signin');
    var signUpDiv = document.querySelector('.signup');
    signInDiv.style.display = 'block';
    signUpDiv.style.display = 'none';
}

async function setRate() {
    const password = document.getElementById("new-password").value;
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

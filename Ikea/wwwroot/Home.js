

async function signUp() {

    const error = document.querySelector('#signup-error');
    error.innerText = '';
    const strength = document.getElementById("strength-rate").value;
    if (strength < 2) {
        error.innerText = "weak password";
        return;
    } 

    const button = document.querySelector('#sign-up-button');
    button.disabled = true;
    button.innerText = 'loading...';
    button.style.backgroudColor = 'grey';

    const email = document.getElementById("new-email").value;
    const password = document.getElementById("new-password").value;
    const firstName = document.getElementById("first-name").value;
    const lastName = document.getElementById("last-name").value;

    const dataToSent = {
        email,
        password,
        firstName,
        lastName
    };

    const res = await fetch("api/users", {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(dataToSent)
    });

    const status = res.status;

    if (status == 200) {
        showSignIn();
    }
    else {
        error.innerText = "sing up process failed";
        button.disabled = false;
        button.innerText = 'Sign Up';
        button.style.backgroudColor = '#F3D963';
    }
}

async function signIn() {
    const button = document.querySelector('#sign-in-button');
    button.disabled = true;
    button.innerText = 'loading...';
    button.style.backgroudColor = 'grey';
    const error = document.querySelector('#signin-error');
    error.innerText = '';

    const email = document.getElementById("email").value;
    const password = document.getElementById("password").value;

    const dataToSent = {
        email,
        password
    }

    const res = await fetch('api/users/signIn', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(dataToSent)
    });



   if (res.status == 200) {
        const user = await res.json();
        sessionStorage.setItem("user", JSON.stringify(user));


        const urlParams = new URLSearchParams(window.location.search);
        const flag = await urlParams.get('fromShoppingBag');

        if (flag) {
            window.location.assign("./ShoppingBag.html");
        }
        else {
            window.location.assign("./UserDetails.html");
        }
    }
    else {
       error.innerText = "user name or password are incorrect";
       const button = document.querySelector('#sign-in-button');
       button.disabled = false;
       button.innerText = 'Sign In';
       button.style.backgroudColor = '#F3D963';
    }
}

function showSignUp() {
    const signInDiv = document.querySelector('.signin');
    const signUpDiv = document.querySelector('.signup');

    signInDiv.style.display = 'none';
    signUpDiv.style.display = 'block';
}

function showSignIn() {
    const signInDiv = document.querySelector('.signin');
    const signUpDiv = document.querySelector('.signup');

    signInDiv.style.display = 'block';
    signUpDiv.style.display = 'none';
}

async function setRate() {
    const password = document.getElementById("new-password").value;

    const result = await fetch("api/password", {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(password)
    });


    const strengthRate = await result.json(); 
    const progress = document.getElementById("strength-rate");
    progress.value = strengthRate;
}

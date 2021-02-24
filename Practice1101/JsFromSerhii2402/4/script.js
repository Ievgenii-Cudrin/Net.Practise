class Validator {
    IsValid() {
        alert("Parrent class!")
    }
}

class EmailValidator extends Validator {
    IsValid(email) {
        const re = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        return re.test(String(email).toLowerCase());
    }
}

class PhoneNumberValidator extends Validator {

    IsValid(number) {
        var re = /^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$/im;
        return re.test(number);
    }
}

function checkEmailAndPhoneNumber() {
    let phoneNumber = document.getElementById("phonenumber").value;
    let email = document.getElementById("email").value;

    let emailValidator = new EmailValidator();
    let phoneNumberValidator = new PhoneNumberValidator();

    let a = emailValidator.IsValid(email);
    let b = phoneNumberValidator.IsValid(phoneNumber);

    if (emailValidator.IsValid(email) && phoneNumberValidator.IsValid(phoneNumber)) {
        alert("success")
    }
    else {
        alert("somethind wrong")
    }
}
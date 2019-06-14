// scripts
if ('serviceWorker' in navigator) { 
    // register service worker 
    navigator.serviceWorker
        .register('/service-worker.js')
        .then(function () {
            console.log('Service worker registered.');
        });
}
$('form').validate({
    rules:{
        password:{
            pwcheck: true
        }
    },
    messages:{
        password:{
            pwcheck: 'Must contain at-least 1 uppercase letter, 1 lowercase letter, 1 number, and one special character.'
        }
    }
});
$('form').on('submit', function (e) {
    e.preventDefault();
    if ($(e.target).valid()) {
        $('#busyIndicator').css('display', 'block');
    }
});
$(':input[type=password]').on('focus', function(e){
    $('.password-strength').css('display','block');
});
$(':input[type=password]').on('focusout', function(e){
    $('.password-strength').attr('data-text','Strength meter');
    $('.password-strength span').css('width','0%');
    $('.password-strength').css('display','none');
});
$(':input[type=password]').on('input', function(e){
    var strenth = getPasswordStrength(e.target.value);
    $('.password-strength span').css('width',strenth+'%');
    if (strenth<=50){
        $('.password-strength span').css('background-color','#c91a1a');
        $('.password-strength').attr('data-text','Strength: Weak');
    }
    else if (strenth<=75){
        $('.password-strength span').css('background-color','#ffc107');
        $('.password-strength').attr('data-text','Strength: Average');
    }
    else if (strenth>75){
        $('.password-strength span').css('background-color','#29ac47');
        $('.password-strength').attr('data-text','Strength: Good');
    }
});
$.validator.addMethod("pwcheck", function (value) {
    return /[\@\#\$\%\^\&\*\(\)\_\+\!]/.test(value) 
    && /[a-z]/.test(value) 
    && /[0-9]/.test(value) 
    && /[A-Z]/.test(value)
});
function getPasswordStrength(pass){
    var index = 0;
    if (hasLowerCase(pass)){
        index++;
    }
    if (hasUpperCase(pass)){
        index++;
    }
    if (hasNumber(pass)){
        index++;
    }
    if (hasSpecialChars(pass)){
        index++;
    }
    return index*25;
}
function hasLowerCase(str) {
    return (/[a-z]/.test(str));
}
function hasUpperCase(str) {
    return (/[A-Z]/.test(str));
}
function hasNumber(str) {
    return (/[0-9]/.test(str));
}
function hasSpecialChars(str){
    return (/[ !@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?]/.test(str));
}
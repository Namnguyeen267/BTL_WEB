const passwordInput = document.getElementById('password');
const showPasswordCheckbox = document.getElementById('showPassword');

showPasswordCheckbox.addEventListener('change', function () {
    const type = this.checked ? 'text' : 'password';
    passwordInput.setAttribute('type', type);
});
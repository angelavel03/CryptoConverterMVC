const getBtn = document.getElementById("btnGet");
const resetBtn = document.getElementById("btnReset");
const howMuch = document.getElementById("howMuch");
const resultConverter = document.getElementById("resultConverter");

getBtn.addEventListener("click", () => {
    if (howMuch.value < 1) {
        alert("Enter a valid amount!");
    }
});

resetBtn.addEventListener("click", () => {
    howMuch.value = '';
    resultConverter.value = '';
});

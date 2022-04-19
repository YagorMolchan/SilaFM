function seemore() {
    let dots = document.getElementById("dots"),
        moreText = document.getElementById("more"),
        btnText = document.getElementById("myBtn");

    if (dots.style.display === "none") {
        dots.style.display = "inline";
        btnText.innerHTML = "EЩЕ";
        moreText.style.display = "none";
    } else {
        dots.style.display = "none";
        btnText.innerHTML = "МЕНЬШЕ";
        moreText.style.display = "inline";
    }
}
  
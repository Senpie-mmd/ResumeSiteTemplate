const btnImgs = document.querySelectorAll(".btnImg");
const targetImg = document.getElementById("targetImg");

function removeActiveClasses() {
    btnImgs.forEach(img => {
        img.classList.remove("active");
    });
};

btnImgs.forEach(img => {
    img.addEventListener("click", () => {
        removeActiveClasses();
        img.classList.add("active");
        switch (img.id) {
            case "img1":
                targetImg.value = "Profile.png";
                break;
            case "img2":
                targetImg.value = "Skills.png";
                break;
            case "img3":
                targetImg.value = "WorkXP.png";
                break;
        }
    });
});
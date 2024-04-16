document.querySelector("#icon").addEventListener("mouseover", (event) => {
  var yazi = document.getElementById('icon');
  yazi.classList.remove("bi-droplet");
  yazi.classList.add("bi-droplet-fill");
})

document.querySelector("#icon").addEventListener("mouseleave", (event) => {
  var yazi = document.getElementById('icon');
  yazi.classList.remove("bi-droplet-fill");
  yazi.classList.add("bi-droplet");
})

document.addEventListener("DOMContentLoaded", function () {
  const penaImg = document.getElementById('pena-id');
  const eksiSeylerImg = document.getElementById('eksi-seyler-id');

  function updateImageSrc() {
    const windowWidth = window.innerWidth;

    if (windowWidth < 1000) {
        penaImg.src = "~/eksi-template/images/pena-sm.png";
        eksiSeylerImg.src = "~/eksi-template/images/eksi-seyler-sm.png";
    } else {
        penaImg.src = "~/eksi-template/images/pena.png";
        eksiSeylerImg.src = "~/eksi-template/images/eksi-seyler.png";
    }
  }

  // Sayfa yüklendiğinde ve pencere boyutu değiştiğinde kontrol et
  window.addEventListener('resize', updateImageSrc);
  updateImageSrc();
});
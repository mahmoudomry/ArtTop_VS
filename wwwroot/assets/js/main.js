inlineSVG.init(
  {
    svgSelector: "img.svg-inline", // the class attached to all images that should be inlined
    initClass: "js-inlinesvg", // class added to <html>
  },
  function () {
    console.log("All SVGs inlined");
  }
);
// Open the full screen search box
function openSearch() {
  document.getElementById("myOverlay").style.display = "block";
}

// Close the full screen search box
function closeSearch() {
  document.getElementById("myOverlay").style.display = "none";
}
let dropdowns = document.querySelectorAll(".dropdown-toggle");
dropdowns.forEach((dd) => {
  dd.addEventListener("click", function (e) {
    var el = this.nextElementSibling;
    el.style.display = el.style.display === "block" ? "none" : "block";
  });
});
document.addEventListener("DOMContentLoaded", function () {
  /////// Prevent closing from click inside dropdown
  document.querySelectorAll(".dropdown-menu").forEach(function (element) {
    element.addEventListener("click", function (e) {
      e.stopPropagation();
    });
  });

  // make it as accordion for smaller screens
  if (window.innerWidth < 992) {
    $(".dropdown-item").on("click", function () {
      $(".submenu").hide();
    });

    document.querySelectorAll(".dropdown-menu a").forEach(function (element) {
      element.addEventListener("click", function (e) {
        let nextEl = this.nextElementSibling;
        if (nextEl && nextEl.classList.contains("submenu")) {
          // prevent opening link if link needs to open dropdown
          e.preventDefault();
          console.log(nextEl);
          if (nextEl.style.display == "block") {
            nextEl.style.display = "none";
          } else {
            nextEl.style.display = "block";
          }
        }
      });
    });
  }
  // end if innerWidth
});
AOS.init();



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
AOS.init();
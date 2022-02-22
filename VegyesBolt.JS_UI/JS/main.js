function include(file) {
  var script = document.createElement("script");
  script.src = `JS/${file}`;
  script.type = "text/javascript";
  script.defer = true;

  document.getElementsByTagName("head").item(0).appendChild(script);
}
include("StandardField.js");
include("DateField.js");
include("AbstractHandler.js");

include("MegyeHandler.js");
include("RestHandler.js");
include("HtmlResources.js");
include("HtmlCreator.js");

function loaded() {
  HtmlCreator.DrawHTMLMegyek().then(
    (x) => (document.getElementById("MegyePlacement").innerHTML = x)
  );
}
console.log("lol");

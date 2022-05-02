function  include(file) {
  var script = document.createElement("script");
  script.src = `JS/${file}`;
  script.type = "text/javascript";
  script.defer = true;

  document.getElementsByTagName("head").item(0).appendChild(script);
}
include("SignalR.js")
include("RestHandler.js");
include("StandardField.js");
include("DateField.js");
include("AbstractHandler.js");


include("MegyeHandler.js");
include("HtmlResources.js");
include("HtmlCreator.js");
function loaded() {

  HtmlCreator.DrawHTMLMegyek().then(
    (x) => (document.getElementById("MegyePlacement").innerHTML = x)
  );
  HtmlCreator.CreateMegyeModal().then(
      (x) =>{document.getElementById("form-modal").innerHTML=x}
  )
  setupSignalR();
}
console.log("lol");

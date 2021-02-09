// This file is to show how a library package may provide JavaScript interop features
// wrapped in a .NET API

window.blazorIntroJs = {
    start: function (elementSelection) {
        introJs(elementSelection).start();
    },
    addHints: function () {
        introJs().addHints();
    }
};

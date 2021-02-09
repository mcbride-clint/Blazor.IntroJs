// This file is to show how a library package may provide JavaScript interop features
// wrapped in a .NET API

window.blazorIntroJs = {
    customOptions: null,
    start: function (elementSelection) {
        try {
            if (blazorIntroJs.customOptions) {
                introJs(elementSelection).setOptions(blazorIntroJs.customOptions).start();
            }
            else {
                introJs(elementSelection).start();
            }
        }
        catch (e) {
            console.log(e);
        }
    },
    startWithOptions: function (options) {

        if (options) {
            introJs().setOptions(options).start();
        } else {
            introJs().start();
        }
    },
    addHints: function (step) {
        if (blazorIntroJs.customOptions) {
            introJs().setOptions(blazorIntroJs.customOptions).addHints(step);
        } else {
            introJs().addHints(step);
        }
    },
    hideHints: function (step) {
        introJs().hideHints(step);
    },
    removeHints: function (step) {
        introJs().removeHints(step);
    },
    showHintDialog: function (step) {
        introJs().showHintDialog(step);
    },
    setOptions: function (options) {
        blazorIntroJs.customOptions = options;
    }

};

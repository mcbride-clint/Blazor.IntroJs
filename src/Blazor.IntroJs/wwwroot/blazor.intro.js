// This file is to show how a library package may provide JavaScript interop features
// wrapped in a .NET API

window.blazorIntroJs = {
    customOptions: null,
    /** 
     *  Implemented
    */
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
/**
*  Implemented
*/
    startWithOptions: function (options) {

        if (options) {
            introJs().setOptions(options).start();
        } else {
            introJs().start();
        }
    },
/**
*  Implemented
*/
    goToStep: function (step) {
        introJs().goToStep(step).start();
    },
/**
*  Implemented
*/
    goToStepNumber: function (step) {
        introJs().goToStepNumber(step).start();
    },
/**
*  Implemented
*/
    exit: function (force) {
        introJs().exit(force);
    },
/**
*  Implemented
*/
    refresh: function () {
            introJs().refresh();
    },
/**
*  Implemented
*/
    addHints: function () {
        if (blazorIntroJs.customOptions) {
            introJs().setOptions(blazorIntroJs.customOptions).addHints();
        } else {
            introJs().addHints();
        }
    },
/**
*  Implemented
*/
    showHint: function (step) {
        introJs().showHint(step);
    },
/**
*  Implemented
*/
    showHints: function () {
        introJs().showHints();
    },
/**
*  Implemented
*/
    hideHint: function (step) {
        introJs().hideHint(step);
    },
/**
*  Implemented
*/
    hideHints: function () {
        introJs().hideHints();
    },
/**
*  Implemented
*/
    removeHints: function (step) {
        introJs().removeHints(step);
    },
/**
*  Implemented
*/
    showHintDialog: function (step) {
        introJs().showHintDialog(step);
    },
/**
*  Implemented
*/
    setOptions: function (options) {
        blazorIntroJs.customOptions = options;
    }

};

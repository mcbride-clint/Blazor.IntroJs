// This file is to show how a library package may provide JavaScript interop features
// wrapped in a .NET API

window.blazorIntroJs = {
    customOptions: null,
    dotNetRef: null,
    /** 
     *  Implemented
    */
    start: function (elementSelection) {
        try {
            if (blazorIntroJs.customOptions) {
                introJs(elementSelection).addEvents().setOptions(blazorIntroJs.customOptions).start();
            }
            else {
                introJs(elementSelection).addEvents().start();
            }
            var x = 0;
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
            introJs().setOptions(options).addEvents().start();
        } else {
            introJs().addEvents().start();
        }
    },
    /**
    *  Implemented
    */
    goToStep: function (step) {
        introJs().goToStep(step).addEvents().start();
    },
    /**
    *  Implemented
    */
    goToStepNumber: function (step) {
        introJs().goToStepNumber(step).addEvents().start();
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
        introJs().addEvents().showHint(step);
    },
    /**
    *  Implemented
    */
    showHints: function () {
        introJs().addEvents().showHints();
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
        introJs().addEvents().showHintDialog(step);
    },
    /**
    *  Implemented
    */
    setOptions: function (options) {
        blazorIntroJs.customOptions = options;
    },
    initialize: function (dotNetRef) {
        blazorIntroJs.dotNetRef = dotNetRef;
    }
};

introJs.fn.addEvents = function () {
    return this
        .oncomplete(function () {
            blazorIntroJs.dotNetRef.invokeMethod("OnCompleteJsEvent");
        })
        .onexit(function () {
            blazorIntroJs.dotNetRef.invokeMethod("OnExitJsEvent");
        })
        .onchange(function (targetElement) {
            blazorIntroJs.dotNetRef.invokeMethod("OnChangeJsEvent", targetElement.localName);
        })
        .onbeforechange(function (targetElement) {
            blazorIntroJs.dotNetRef.invokeMethod("OnBeforeChangeJsEvent", targetElement.localName);
        })
        .onafterchange(function (targetElement) {
            blazorIntroJs.dotNetRef.invokeMethod("OnAfterChangeJsEvent", targetElement.localName);
        })
        .onhintclick(function () {
            blazorIntroJs.dotNetRef.invokeMethod("OnHintClickJsEvent");
        })
        .onhintsadded(function () {
            blazorIntroJs.dotNetRef.invokeMethod("OnHintsAddedJsEvent");
        })
        .onhintclose(function () {
            blazorIntroJs.dotNetRef.invokeMethod("OnHintCloseJsEvent");
        })
        .onbeforeexit(function () {
            return blazorIntroJs.dotNetRef.invokeMethod("OnBeforeExitJsEvent");
        });
}
// This file is to show how a library package may provide JavaScript interop features
// wrapped in a .NET API



window.blazorIntroJs = {
    introJsInstances: {},
    applyStepStatus: function (introJs, status) {
        if (status.goToStep) {
            introJs.goToStep(status.goToStep);
        }

        if (status.goToStepNumber) {
            introJs.goToStepNumber(status.goToStepNumber);
        }
    },
    applyTargetElement: function (id, elementSelection) {
        if (typeof elementSelection === "string") {
            //select the target element with query selector
            const targetElement = document.querySelector(elementSelection);

            if (targetElement) {
                this.introJsInstances[id]._targetElement = targetElement;
            } else {
                throw new Error("There is no element with given selector.");
            }
        }
    },
    /** 
     *  Implemented
    */
    start: function (id, status, elementSelection) {
        this.applyTargetElement(id, elementSelection);
        this.applyStepStatus(this.introJsInstances[id], status);

        try {
            this.introJsInstances[id].start();
        }
        catch (e) {
            console.log(e);
        }
    },
    /**
    *  Implemented
    */
    goToStep: function (id, step) {
        this.introJsInstances[id].goToStep(step);
    },
    /**
    *  Implemented
    */
    goToStepNumber: function (id, step) {
        this.introJsInstances[id].goToStepNumber(step);
    },
    /**
    *  Implemented
    */
    exit: function (id, force) {
        this.introJsInstances[id].exit(force);
    },
    /**
    *  Implemented
    */
    refresh: function (id) {
        this.introJsInstances[id].refresh();
    },
    /**
    *  Implemented
    */
    addHints: function (id) {
        this.introJsInstances[id].addHints();
    },
    /**
    *  Implemented
    */
    showHint: function (id, step) {
        this.introJsInstances[id].showHint(step);
    },
    /**
    *  Implemented
    */
    showHints: function (id) {
        this.introJsInstances[id].showHints();
    },
    /**
    *  Implemented
    */
    hideHint: function (id, step) {
        this.introJsInstances[id].hideHint(step);
    },
    /**
    *  Implemented
    */
    hideHints: function (id) {
        this.introJsInstances[id].hideHints();
    },
    /**
    *  Implemented
    */
    removeHints: function (id, step) {
        this.introJsInstances[id].removeHints(step);
    },
    /**
    *  Implemented
    */
    showHintDialog: function (id, step) {
        this.introJsInstances[id].showHintDialog(step);
    },
    /**
    *  Implemented
    */
    setOptions: function (id, options) {
        this.introJsInstances[id].setOptions(options);
    },
    initialize: function (id, dotNetRef) {
        this.introJsInstances[id] = introJs();
        this.introJsInstances[id].addEvents(dotNetRef);
    },
    dispose: function (id) {
        this.removeHints(id);
        delete this.introJsInstances[id];
    }
};

introJs.fn.getEventArgs = function () {
    let args = {
        CurrentStep: this._currentStep,
        Direction: this._direction
    };
    return args;
}

introJs.fn.addEvents = function (dotNetRef) {
    return this
        .oncomplete(function () {
            dotNetRef.invokeMethod("OnCompleteJsEvent", this.getEventArgs());
        })
        .onexit(function () {
            dotNetRef.invokeMethod("OnExitJsEvent", this.getEventArgs());
        })
        .onchange(function (targetElement) {
            dotNetRef.invokeMethodAsync("OnChangeJsEvent", targetElement, this.getEventArgs());
        })
        .onbeforechange(function (targetElement) {
            return dotNetRef.invokeMethod("OnBeforeChangeJsEvent", targetElement, this.getEventArgs());
        })
        .onafterchange(function (targetElement) {
            dotNetRef.invokeMethodAsync("OnAfterChangeJsEvent", targetElement, this.getEventArgs());
        })
        .onhintclick(function () {
            dotNetRef.invokeMethod("OnHintClickJsEvent", this.getEventArgs());
        })
        .onhintsadded(function () {
            dotNetRef.invokeMethod("OnHintsAddedJsEvent", this.getEventArgs());
        })
        .onhintclose(function () {
            dotNetRef.invokeMethod("OnHintCloseJsEvent", this.getEventArgs());
        })
        .onbeforeexit(function () {
            return dotNetRef.invokeMethod("OnBeforeExitJsEvent", this.getEventArgs());
        });
}
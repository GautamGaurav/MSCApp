function addFiles() {
    var controllerJs = "adminTeacher--controller.js"
    var serviceJs = "adminTeacher--services.js"
    var controllerPath = "../app/admin/subject/controllers/";
    var servicePath = "../app/admin/subject/services/";

    var url = window.location.pathname;
    if (url.indexOf("teacher") > -1) {

    } else if (url.indexOf("teacher") > -1) {

    } else if (url.indexOf("subject") > -1) {

    } else if (url.indexOf("subject") > -1) {

    } else if (url.indexOf("subject") > -1) {

    } else if (url.indexOf("subject") > -1) {

    }



    var controllerScriptFile = document.createElement('script');
    controllerScriptFile.src = controllerPath + '/' + controllerJs;
    document.getElementsByTagName('head')[0].appendChild(controllerScriptFile);


    var servicesScriptFile = document.createElement('script');
    servicesScriptFile.src = servicesPath + '/' + servicesJs;
    document.getElementsByTagName('head')[0].appendChild(servicesScriptFile);
}

window.onload = addFiles;

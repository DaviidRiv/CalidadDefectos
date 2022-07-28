function validarfor(){

    var date = document.getElementById("date")[0].value; 
    var week = document.getElementsByName("week")[0].value;
    var serial = document.getElementsByName("serial")[0].value;
    var job = document.getElementsByName("job")[0].value;
    var ensamble = document.getElementsByName("ensamble")[0].value;
    var compo = document.getElementsByName("compo")[0].value;
    var descripcion = document.getElementsByName("descipcion")[0].value;

    var expr = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;


    /*if ( !expr.test(correo) ){                                                            //COMPRUEBA MAIL
        alert("Error: La dirección de correo " + correo + " es incorrecta.");
        return false;
    }*/

    if ((date == "") || (week == "") || (serial == "") || (job == "") || (ensamble == "") || (compo == "") || (descripcion == "")) {  //COMPRUEBA CAMPOS VACIOS
        alert("Los campos no pueden quedar vacios");
        return true;
    }

}
function enviarServidor(url,metodo) {
    var xhr = new XMLHttpRequest();
    xhr.open("get", url, true);
    xhr.onreadystatechange = function () {
        if (xhr.readyState == 4 && xhr.status == 200) {
            metodo(xhr.responseText);
        }
    }
    xhr.send();
}

function validarCampo(Tex, Mensaje) {
    var Texto = document.getElementById(Tex);
    if (Texto != null) {
        if (Texto.value.replace(/^\s+|\s+$/g, "").length == 0) {
            alert('¡¡¡ Favor de Ingresar ' + Mensaje);
            Texto.focus();
            return false;
        }
        if (Texto.value.match(/([\<])([^\>]{1,})*([\>])/i) != null) {
            alert(Mensaje + ' No debe contener etiquetas html: <etiqueta>');
            Texto.select();
            Texto.focus();
            return false;
        }
        if (Texto.value.match(/[,;]+/) != null) {
            alert(Mensaje + ' No debe contener , o ;');
            Texto.select();
            Texto.focus();
            return false;
        }
    }
    return true;
}

window.onload = function () {
    var btnAceptar = document.getElementById("btnAceptar");
    btnAceptar.onclick = function () {
        
        if (validarCampo("Usuario", "Usuario") == false) return false;
        if (validarCampo("Password", "Clave") == false) return false;
        var txtUsuario = document.getElementById("Usuario");
        var txtClave = document.getElementById("Password");
        txtClave.value = CryptoJS.MD5(txtClave.value);
        var url = "../Login/Validar/?usuario=" + txtUsuario.value + "&clave=" + txtClave.value;
        enviarServidor(url, validarLogin);
    }
}

function mostrarCaptcha(rpta) {
    var imgCaptcha = document.getElementById("imgCaptcha");
    imgCaptcha.src = "data:image/png;base64," + rpta;
}

function validarLogin(rpta) {
    if (rpta.substring(0, 10) == "Bienvenido") {
        url = "../NotaIngreso/Index";
        window.location = url;
    }
    else
    {
        alert(rpta);
    }
}
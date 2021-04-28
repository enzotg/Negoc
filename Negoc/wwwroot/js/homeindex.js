window.addEventListener("load", window_onload);

function window_onload() {

    getOfertas()
        .then(function () { cardInit(); });

}
function getOfertas() {

    const promise = new Promise(function (resolve, reject) {
        $.ajax({
            url: "/Listar/GetProductosEnOferta?OfertaId=1",
            type: 'get',
            dataType: 'json'
        }).then(function (data) {
            AgregarOfertas(data);
            resolve();
        });
    });

    return promise;
}
function AgregarOfertas(data) {

    let arr = JSON.parse(data);
    let cont = document.getElementById("contcards");

    arr.forEach(function (value, index, array) {
        let contcard = ArmarProductoItem(value);
        cont.appendChild(contcard);        
    });
}

function ArmarProductoItem(elem) {

    let contcard = document.createElement("div");
    contcard.classList = "contcards-item";

    let item = document.createElement("div");
    item.classList = "producto-item";

    let a = document.createElement("a");
    a.href = "/Listar/GetProductoList?ProductoId=" + elem.ProductoId;

    let img = document.createElement("img");
    img.classList = "producto-imagen";
    img.src = "/Listar/GetImagePr/" + elem.ProductoId;
    img.alt = "";
    a.appendChild(img);

    let spanPr = document.createElement("span");
    spanPr.classList = "producto-precio";
    spanPr.innerText = "$ " + elem.Precio;

    let spanMar = document.createElement("span");
    spanMar.classList = "producto-marca";
    spanMar.innerText = elem.Marca;
    let divMar = document.createElement("div");
    divMar.appendChild(spanMar);

    let descr = document.createElement("p");
    descr.classList = "producto-descr";
    descr.innerText = elem.Descripcion;

    contcard.appendChild(item);

    item.appendChild(a);
    item.appendChild(spanPr);
    item.appendChild(divMar);
    item.appendChild(document.createElement("hr"));
    item.appendChild(descr);

    if (elem.EnvioGratis) {
        let envio = document.createElement("div");
        let enviot = document.createElement("p");
        enviot.classList = "producto-envio";
        enviot.innerText = "Envio gratis";
        envio.appendChild(enviot);
        item.appendChild(envio);
    }
    return contcard;
}


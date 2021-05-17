window.addEventListener("load", window_onload);

function window_onload() {

    getOfertas();

}
function getOfertas() {

    $.ajax({
        url: "/Listar/GetProductosEnOferta?OfertaId=1",
        type: 'get',
        dataType: 'json'
    }).then(function (data) {
        AgregarOfertas(
            document.querySelector("#contcarouselb0 .carouselb-inner"),
            data);
    });

    for (let i = 1; i <= 3; i++) {

        $.ajax({
            url: "/Listar/GetProductosHome?GeneroId=" + i,
            type: 'get',
            dataType: 'json'
        }).then(function (data) {
            AgregarOfertas(
                document.querySelector("#contcarouselb" + i + " .carouselb-inner"),
                data);
        });
    }
}

function AgregarOfertas(cont, data) {

    let arr = JSON.parse(data);    

    arr.forEach(function (value) {
        let contcard = ArmarProductoItem(value);
        cont.appendChild(contcard);
    });

    /*
    let cont0 = document.querySelector("#contcarouselb0 .carouselb-inner");

    arr.forEach(function (value) {
        let contcard = ArmarProductoItem(value);
        cont0.appendChild(contcard);
    });

    let conta = document.querySelector("#contcarouselb1 .carouselb-inner");

    arr.forEach(function (value) {
        let contcard = ArmarProductoItem(value);
        conta.appendChild(contcard);        
    });

    let contb = document.querySelector("#contcarouselb2 .carouselb-inner");

    arr.forEach(function (value) {
        let contcard = ArmarProductoItem(value);
        contb.appendChild(contcard);
    });

    let contc = document.querySelector("#contcarouselb3 .carouselb-inner");

    arr.forEach(function (value) {
        let contcard = ArmarProductoItem(value);
        contc.appendChild(contcard);
    });
    */
    
}

function ArmarProductoItem(elem) {

    let contcard = document.createElement("div");
    //contcard.classList = "contcards-item";
    contcard.classList = "carouselb-item";
    contcard.setAttribute("data-id", elem.ProductoId);

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


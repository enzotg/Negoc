var keyCarro = "Carro";
var carro = [];

function CarroItem(itemId, prodId, NombreProd, cant, precio, total) {

    this.CarroItemId = itemId;
    this.ProductoId = prodId;
    this.NombreProd = NombreProd;
    this.Cantidad = cant;
    this.Precio = precio;
    this.Total = total;
}

window.addEventListener("load", window_onload);

function window_onload() {

    if (localStorage.getItem(keyCarro)) {

        carro = JSON.parse(localStorage.getItem(keyCarro));

        $.ajax({
            url: '/Carro/ActualizarCarro',
            contentType: 'application/json; charset=utf-8',
            type: 'post',
            data: JSON.stringify(carro),
            dataType: 'json'
        }).then(function (data) {
            let res = JSON.parse(data);
            LlenarCarro(res);
        });
    }
}


function AgrControlCantidad(e, val) {
    var divA = document.createElement("div");
    divA.className = "cantidad-marco";

    var divB = document.createElement("div");
    divB.className = "cantidad-marco-nro";

    var divC = document.createElement("div");
    divC.className = "cantidad-marco-nrob";

    var inp = document.createElement("input");
    inp.className = "cantidad-numero";
    //inp.id = "txtCantidad";
    inp.value = val;

    var divD = document.createElement("div");
    divD.className = "cantidad-marco-fl";

    var divfl1 = document.createElement("div");
    divfl1.className = "cantidad-fl";
    divfl1.innerText = "🡱";
    divfl1.onclick = function () { MoverCant(inp, e.parentElement.getAttribute('data-id'), 1, e.nextElementSibling, e.nextElementSibling.nextElementSibling); };
    var divfl2 = document.createElement("div");
    divfl2.className = "cantidad-fl";
    divfl2.innerText = "🡳";
    divfl2.onclick = function () { MoverCant(inp, e.parentElement.getAttribute('data-id'), -1, e.nextElementSibling, e.nextElementSibling.nextElementSibling); };



    divA.appendChild(divB);
    divB.appendChild(divC);
    divC.appendChild(inp);
    divA.appendChild(divD);
    divD.appendChild(divfl1);
    divD.appendChild(divfl2);

    e.appendChild(divA);
}
function CalcTotal() {

    let pr = 0;
    document.querySelectorAll(".col-total-precio-item")
        .forEach(function (value, index) {
            if (value.innerText != "")
                pr += Number.parseFloat(value.innerText.substring(1));
        });
    document.getElementById("totalCarro").innerText = "$" + pr;
}
function MoverCant(e, ProductoId, val, precio, total) {

    var res = Number.parseInt(e.value) + val;
    if (res < 0 || res > 1000) return;

    e.value = res;
    total.innerText = "$" + res * precio.innerText.substring(1);

    //Modificar en el carro
    carro.forEach(function (value, index, array) {
        if (value.ProductoId == ProductoId) {
            value.Cantidad = res;

        }
    });
    localStorage.setItem(keyCarro, JSON.stringify(carro));
    CalcTotal();
}

function QuitarItem(e) {
    var elem = e.parentElement.parentElement;
    var id = elem.firstElementChild.firstElementChild.name;
    e.parentElement.parentElement.remove();

    carro.forEach(function (value, index, array) {
        if (value.ProductoId == id)
            array.splice(index, 1);
        //console.log(array[index]);
        //carro[index].remove();
    });

    localStorage.setItem(keyCarro, JSON.stringify(carro));
}
function LlenarCarro(data) {

    var cont = document.getElementById("ContenedorCarro");
    data.forEach((elem, index, array) => {
        var fila = document.createElement("div");
        fila.classList = "fila";
        fila.setAttribute('data-id', elem.ProductoId);

        var divA = document.createElement("div");
        //divA.innerText = elem.ProductoId;
        divA.classList = "col-img";
        //divA.style.display = "none";

        var alink = document.createElement("a");
        alink.href = "/Listar/GetProductoList?ProductoId=" + elem.ProductoId;
        alink.name = elem.ProductoId;

        var img = document.createElement("img");
        img.src = "/Listar/GetImagePr/" + elem.ProductoId;
        img.alt = elem.Nombre;
        img.classList = "carro-img";
        alink.appendChild(img);
        divA.appendChild(alink);

        var divB = document.createElement("div");
        divB.innerText = elem.NombreProd;
        divB.classList = "col";

        var divC = document.createElement("div");
        //divC.innerText = elem.Cantidad;
        divC.classList = "col col-cant";
        AgrControlCantidad(divC, elem.Cantidad);

        var divD = document.createElement("div");
        divD.innerText = '$' + elem.Precio;
        divD.classList = "col col-un-precio-item";

        var divE = document.createElement("div");
        divE.innerText = '$' + elem.Total;
        divE.classList = "col col-total-precio-item";

        var divF = document.createElement("div");
        divF.classList = "col col-cerrar";

        var btn = document.createElement("button");
        btn.classList = "btn-quitar-item";
        btn.onclick = function () { QuitarItem(this); };
        btn.innerHTML = "<div class='ico-cerrar'>&#10006;</div>";

        divF.appendChild(btn);


        fila.appendChild(divA);
        fila.appendChild(divB);
        fila.appendChild(divC);
        fila.appendChild(divD);
        fila.appendChild(divE);
        fila.appendChild(divF);

        cont.appendChild(fila);
        CalcTotal();
    });

}

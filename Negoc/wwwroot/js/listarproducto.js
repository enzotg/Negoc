var keyCarro = "Carro";
var carro = [];

//-------------------------------------------------------------
window.onload = function () {

    GetCategoriasP(document.getElementById("productoId").value);
}

function CarroItem(itemId, prodId, NombreProd, cant, precio, total) {

    this.CarroItemId = itemId;
    this.ProductoId = prodId;
    this.NombreProd = NombreProd;
    this.Cantidad = cant;
    this.Precio = precio;
    this.Total = total;
}

function GetCategoriasP(prodId) {
    $.ajax({
        url: '/Listar/GetCategoriasParents?ProductoId=' + prodId,
        type: 'Get',
        dataType: 'json'
    }).then(function (data) {
        let arr = JSON.parse(data);
        let cont = document.getElementById("CategoriasP");

        arr.forEach(function (elem, index, array) {

            let op = document.createElement("a");
            op.href = "/Listar/GetProductos?CategoriaId=" + elem.CategoriaId + "&PagNumero=1&PagCantidad=10&TipoOrden=1";
            op.className = "";
            op.innerText = elem.Nombre;
            cont.appendChild(op);

            if (index != (array.length - 1)) {
                let span = document.createElement("span");
                span.innerText = " \\ ";
                cont.appendChild(span);
            }
        });
    });
}

function AgregarCarr(e, ProductoId) {

    if (localStorage.getItem(keyCarro))
        carro = JSON.parse(localStorage.getItem(keyCarro));

    let index = carro.findIndex(v => v.ProductoId == ProductoId);
    if (index >= 0)
        carro[index].Cantidad += 1;
    else {
        let item = new CarroItem(1, ProductoId, '', 1, 0, 0);
        carro.push(item);
    }
    localStorage.setItem(keyCarro, JSON.stringify(carro));
    $('#exampleModalCenter').modal();
}


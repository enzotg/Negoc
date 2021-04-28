window.addEventListener("load", window_onload);

function window_onload() {

    getQryVal();
    getMarcas();
    getColores();
    getDeportes();
    getCategorias();
    //----------------------------------------------------
    $.ajax({
        url: "/Listar/GetProductosCantPag" + getQryNue(1),
        type: 'Post',
        dataType: 'json'
    }).then(function (data) {

        document.getElementById("txtPageCant").value = data;

        if (parseInt(document.getElementById("txtPageNumber").value) == parseInt(document.getElementById("txtPageCant").value))
            document.getElementById("pagSiguiente").style.visibility = 'hidden';
    });
}

function AgregarFiltro(Nombre, valor) {

    if (valor == 0 || valor == null) return;

    let cont = document.getElementById("listaFiltros");
    let btn = document.createElement("button");
    let spA = document.createElement("span");
    let spB = document.createElement("span");

    let b = document.getElementById("filtro" + Nombre);
    if (b) b.remove();

    btn.type = "button";
    btn.classList = "btn btn-light";
    btn.name = valor;
    btn.id = "filtro" + Nombre;
    spA.innerText = Nombre;
    spB.innerText = "X";
    spB.classList = "badge badge-light";
    spB.style = "border:1px solid silver;border-radius:6px;margin:4px";
    btn.onclick = function (e) { QuitarFiltro(e); }

    btn.appendChild(spA);
    btn.appendChild(spB);
    cont.appendChild(btn);

}
function QuitarFiltro(e) {
    e.currentTarget.remove();
    moverPag(0);
}
function FiltrarPrecio() {
    AgregarFiltro("Precio", 1);
    moverPag(0);
}
function getFromQry(e) {
    const queryString = window.location.search;
    const urlParams = new URLSearchParams(queryString);
    return urlParams.get(e) == undefined ? 0 : urlParams.get(e);
}

function getQryVal() {
    //Leer todos los param y cargarlos en filtros
    const queryString = window.location.search;
    const urlParams = new URLSearchParams(queryString);

    let catId = urlParams.get('CategoriaId');
    let genId = urlParams.get('GeneroId');
    let marcaId = urlParams.get('MarcaId');
    let colorId = urlParams.get('ColorId');
    let deporteId = urlParams.get('DeporteId');
    let precioD = urlParams.get('PrecioD');
    let precioH = urlParams.get('PrecioH');
    let descripcion = urlParams.get('Descripcion');
    let pagNum = urlParams.get('PagNumero');
    let pagSiz = urlParams.get('PagCantidad');
    let tipoOrden = urlParams.get('TipoOrden');

    document.getElementById("precioD").value = precioD;
    document.getElementById("precioH").value = precioH;
    document.getElementById("txtPageNumber").value = pagNum;
    document.getElementById("selectPageSize").value = pagSiz;
    document.getElementById("selectId").value = tipoOrden;

    AgregarFiltro("Categoria", catId);
    AgregarFiltro("Genero", genId);
    AgregarFiltro("Marca", marcaId);
    AgregarFiltro("Color", colorId);
    AgregarFiltro("Deporte", deporteId);
    AgregarFiltro("Precio", precioD);
    AgregarFiltro("Descripcion", descripcion);

}
function moverPag(n) {

    let pagNum = document.getElementById("txtPageNumber").value;
    pagNum = parseInt(pagNum) + n;

    if (pagNum <= 0) return;

    document.getElementById("txtPageNumber").value = pagNum;

    let urlProd = "/Listar/GetProductos" + getQryNue(1);
    //let cant = @Model.Count();

    window.location.href = urlProd;


}
//CategoriaId, GeneroId, MarcaId, ColorId, PrecioD, PrecioH, Descripcion, PagNumero, PagCantidad, TipoOrden
function getQryNue(e) {
    // 1  es todos
    //get query con todos los param
    //get query sin pag numero pag cant

    let catId = document.getElementById("filtroCategoria") != null ? document.getElementById("filtroCategoria").name : 0;
    let genId = document.getElementById("filtroGenero") != null ? document.getElementById("filtroGenero").name : 0;
    let marcaId = document.getElementById("filtroMarca") != null ? document.getElementById("filtroMarca").name : 0;
    let colorId = document.getElementById("filtroColor") != null ? document.getElementById("filtroColor").name : 0;
    let deporteId = document.getElementById("filtroDeporte") != null ? document.getElementById("filtroDeporte").name : 0;
    let descripcion = document.getElementById("filtroDescripcion") != null ? document.getElementById("filtroDescripcion").name : '';
    let precioD = 0;
    let precioH = 0;

    if (document.getElementById("filtroPrecio")) {
        precioD = document.getElementById("precioD").value;
        precioH = document.getElementById("precioH").value;
    }

    let tipoOrden = document.getElementById("selectId").value;
    let pagNum = document.getElementById("txtPageNumber").value;
    let pagSiz = document.getElementById("selectPageSize").value;
    let queryStringNue = '';

    if (e == 1)
        queryStringNue = "?CategoriaId=" + catId + "&GeneroId=" + genId + "&MarcaId=" + marcaId + "&ColorId=" + colorId + "&DeporteId=" + deporteId + "&PrecioD=" + precioD + "&PrecioH=" + precioH + "&Descripcion=" + descripcion + "&PagNumero=" + pagNum + "&PagCantidad=" + pagSiz + "&TipoOrden=" + tipoOrden;
    else
        queryStringNue = "?CategoriaId=" + catId + "&GeneroId=" + genId + "&MarcaId=" + marcaId + "&ColorId=" + colorId + "&DeporteId=" + deporteId + "&PrecioD=" + precioD + "&PrecioH=" + precioH + "&Descripcion=" + descripcion + "&TipoOrden=" + tipoOrden;

    return queryStringNue;
}
function reempQry(qry, reem) {

    let str = qry.toString();
    let ini = str.indexOf(reem);
    let fin = str.indexOf("&", ini);
    return str.substring(0, ini) + reem + "0" + str.substring(fin);
}
function getMarcas() {

    let res = reempQry(getQryNue(), "MarcaId=");
    let urlg = "/Listar/GetMarcas" + res;

    $.ajax({
        url: urlg,
        type: 'Get',
        dataType: 'json'
    }).then(function (data) {
        let arr = JSON.parse(data);
        let select = document.getElementById("selectMarcas");

        arr.forEach(function (elem, index, array) {
            let op = document.createElement("a");
            op.href = "javascript:void(0)";
            op.className = "dropdown-item";
            op.innerText = elem.Nombre;
            op.onclick = function () { AgregarFiltro("Marca", elem.MarcaId); moverPag(0); }
            select.appendChild(op);
        });

    });
}

function getColores() {

    let res = reempQry(getQryNue(), "ColorId=");
    let urlg = "/Listar/GetColores" + res;

    $.ajax({
        url: urlg,
        type: 'Get',
        dataType: 'json'
    }).then(function (data) {
        let arr = JSON.parse(data);
        let select = document.getElementById("selectColores");

        arr.forEach(function (elem, index, array) {
            let op = document.createElement("a");
            op.href = "javascript:void(0)";
            op.className = "dropdown-item";
            op.innerText = elem.Nombre;
            op.onclick = () => { AgregarFiltro("Color", elem.ColorId); moverPag(0); }
            select.appendChild(op);
        });

    });
}

function getDeportes() {

    let res = reempQry(getQryNue(), "DeporteId=");
    let urlg = "/Listar/GetDeportes" + res;

    $.ajax({
        url: urlg,
        type: 'Get',
        dataType: 'json'
    }).then(function (data) {
        let arr = JSON.parse(data);
        let select = document.getElementById("selectDeportes");

        arr.forEach(function (elem, index, array) {
            let op = document.createElement("a");
            op.href = "javascript:void(0)";
            op.className = "dropdown-item";
            op.innerText = elem.Nombre;
            op.onclick = () => { AgregarFiltro("Deporte", elem.DeporteId); moverPag(0); }
            select.appendChild(op);
        });

    });
}

function getCategorias() {
    $.ajax({
        url: "/Listar/GetCategorias?CategoriaId=0&NivelId=5",
        method: "GET",
        dataType: 'json'
    }).then(function (data) {

        let res = JSON.parse(data);
        let contain = document.getElementById("categorias");
        res.forEach(function (elem, index, array) {
            if (elem.NivelId == 1) {
                let divR = document.createElement("div");
                divR.id = elem.CategoriaId;

                let spText = document.createElement("span");
                spText.innerText = elem.Nombre;
                spText.addEventListener('click', function (e) { e.cancelBubble = true; CategoriaClick(e); });
                let spIco = document.createElement("span");
                spIco.innerHTML = "|+|";
                spIco.className = "categoria-icono";
                spIco.addEventListener('click', function (e) { e.cancelBubble = true; CategoriaDisp(e); });

                divR.appendChild(spIco);
                divR.appendChild(spText);

                contain.appendChild(divR);
            }
            else {
                let nodo = document.getElementById(elem.ParentId);
                if (nodo == null) { //no existe
                }
                else {
                    let divR = document.createElement("div");
                    divR.style.display = "none";
                    divR.id = elem.CategoriaId;
                    nodo.appendChild(divR);

                    let spText = document.createElement("span");
                    spText.innerText = elem.Nombre;
                    spText.addEventListener('click', function (e) { e.cancelBubble = true; CategoriaClick(e); });
                    let spIco = document.createElement("span");
                    spIco.innerHTML = "|+|";
                    spIco.className = "categoria-icono";
                    spIco.addEventListener('click', function (e) { e.cancelBubble = true; CategoriaDisp(e); });

                    divR.appendChild(spIco);
                    divR.appendChild(spText);

                }
            }
        });
    });
}

function CategoriaDisp(e) {
    if (e.target.innerHTML.indexOf("+") < 0)
        e.target.innerHTML = e.target.innerHTML.replace("-", "+");
    else
        e.target.innerHTML = e.target.innerHTML.replace("+", "-");

    e.target.parentElement
        .childNodes
        .forEach(function (elem, index, array) {
            if (elem.tagName == "DIV") {
                if (elem.style.display != "none")
                    elem.style.display = "none";
                else
                    elem.style.display = "block";
            }
        });
}

function CategoriaClick(e) {
    let catId = e.target.parentElement.id;
    AgregarFiltro("Categoria", catId);
    moverPag(0);
}

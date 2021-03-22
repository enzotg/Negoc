var sl1;
var sl2;
var indexCurr = 0;
var indexSig = 1;

/************/
function VerImgPrinc(e){
    document.getElementById("produnImagen").src = e.src;
    indexCurr=0;
    var t = document.getElementsByClassName("thumb-img");
    while(document.getElementById("produnImagen").src != t[indexCurr].src)
        indexCurr++;
}
function moverImg(n){
    indexCurr += n;
    var t = document.getElementsByClassName("thumb-img").length - 1;
    if(indexCurr < 0) indexCurr=t;
    if(indexCurr > t) indexCurr=0;        
    document.getElementById("produnImagen").src = document.getElementsByClassName("thumb-img")[indexCurr].src;        
}
/**************/

function mostrarGal(){
    document.getElementsByClassName("container-slide-back")[0].classList += " activo";      

    //sl1 = document.querySelectorAll(".slide")[indexCurr];         
    //sl1.classList = "slide sig-a-centro activo";
    IrA(indexCurr);
}

function cerrarContainer(){
    var c = document.getElementsByClassName("container-slide-back")[0];        
    c.className = c.className.replace("activo", "");  
    //oc todos slide
    var t = document.querySelectorAll(".slide");
    for(var i = 0; i < t.length; i++)    //inact todos
        t[i].classList = "slide inactivo"; 
    var t = document.querySelectorAll(".dot");
    for(var i = 0; i< t.length; i++)    //inact todos
        t[i].classList = "dot";             

}

function mover(i){
           
    indexSig = indexCurr + i;
    if(indexSig >= document.querySelectorAll(".slide").length)
        indexSig = 0;
    if(indexSig<0)    
        indexSig = document.querySelectorAll(".slide").length-1;

    sl1 = document.querySelectorAll(".slide")[indexCurr]; 
    sl2 = document.querySelectorAll(".slide")[indexSig];     
    
    var t = document.querySelectorAll(".dot");
    for(var i = 0; i< t.length; i++)    //inact todos
        t[i].classList = "dot"; 
    document.querySelectorAll(".dot")[indexSig].classList = "dot dot-activo"; 

    if(i>0) SlideSiguiente(); else SlideAnterior();
    
    indexCurr = indexSig;
    moverImg(0);
}

function IrA(n){
    sl1 = document.querySelectorAll(".slide")[indexCurr]; 
    sl2 = document.querySelectorAll(".slide")[n]; 
    document.querySelectorAll(".dot")[indexCurr].classList = "dot"; 
    document.querySelectorAll(".dot")[n].classList = "dot dot-activo"; 

    if(indexCurr<n)
        SlideSiguiente();
    else
        SlideAnterior();
    indexCurr=n;
    moverImg(0);
}

function SlideSiguiente(){                

    AIzqSeVa()
    .then(()=>{
        return Inactivar();
    })
    .then(()=>{
        return ADerOc();
    })
    .then(()=>{
        return ACentro();
    });
}
function SlideAnterior(){        
    
    ADerSeVa()
    .then(()=>{
        return Inactivar();
    })
    .then(()=>{
        return AIzqOc();
    })
    .then(()=>{
        return ACentro();
    });

}
function AIzqSeVa(){        
    return new Promise(function(resolve, reject) {             
        sl1.classList = "slide sig-a-izq activo";         
        setTimeout(resolve, 500);
    });        
}
function ADerSeVa(){
    return new Promise(function(resolve, reject) {             
        sl1.classList = "slide sig-a-der activo";         
        setTimeout(resolve, 500);
    });        
}    
function Inactivar(){
    return new Promise(function(resolve, reject) { 
        sl1.classList = "slide inactivo"; 
        sl2.classList = "slide inactivo"; 
        setTimeout(resolve, 0);
    });
}
function ADerOc(){
    return new Promise(function(resolve, reject) {                 
        sl2.classList = "slide sig-a-der-oc ";            
        setTimeout(resolve,  100 );
    });                
}
function AIzqOc(){
    return new Promise(function(resolve, reject) {     
        sl2.classList = "slide sig-a-izq-oc ";            
        setTimeout(resolve,  100 );
    });                
}
function ACentro(){
    return new Promise(function(resolve, reject) {                         
        sl2.classList = "slide sig-a-centro activo";
        setTimeout(resolve, 500);
    });                
}

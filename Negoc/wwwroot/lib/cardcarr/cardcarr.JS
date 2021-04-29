var cardsT;
var cardWith;
var cardCont;
var timeoutCards ;
var cssTransA;
var cssTransB;


window.addEventListener("load", function (event) {
<<<<<<< HEAD
    cardInit();    
=======
    //cardInit();    
>>>>>>> 732283587911371be4fc8312a3aa766a48e3ce57
}, false);

window.addEventListener("resize", function (event) {
    contcardsRecalc();
}, false);

function cardInit() {
    document.getElementById("contprinc-Sig").addEventListener("click", siguiente);
    document.getElementById("contprinc-Ant").addEventListener("click", anterior);

    cardCont = document.getElementById("contcards");
    cardsT = cardCont.cloneNode(true).children;
    cardWith = cardCont.firstElementChild.offsetWidth;
    timeoutCards = 500;
    cssTransA = 'linear .3s';
    cssTransB = 'linear .5s';

    contcardsRecalc();
}

function contcardsRecalc(){                                    
    quitarR();
    agregarR();            
}
function quitarR(){
    //los q no entran quitar            
    var res = getTotal() - document.body.offsetWidth;
    while(res > 0 &&  cardCont.children.length > 1 )
    {
        cardCont.removeChild( cardCont.lastElementChild);
        res -= cardCont.firstElementChild.offsetWidth;
    }
}
function agregarR(){
    var i;
    for(i=0;i<cardsT.length;i++)
        if(cardsT[i].innerHTML== cardCont.lastElementChild.innerHTML)
            break;
    i++;            
    while(i<cardsT.length){
        var node = cardsT[i].cloneNode(true);
        if(encaj()  ) //fit ?
             cardCont.appendChild(node);                    
        else
            break;
        i++;
    }             
}
function anterior(){            
    
    var lastChild =  cardCont.firstElementChild;            

    AnimarBorrar('')
    .then(()=> {
        return borrarTodos();
    })            
    .then(()=>{
        return AgregarAAntes(lastChild);
    })
    .then(()=>{
        return EnviarIzq();
    })
    .then(()=> {
        return AnimarDer(); 
    });
    //.catch(fail);
}

function siguiente(){            
    
    var lastChild =  cardCont.lastElementChild;            

    AnimarBorrar('-')
    .then(()=> {
        return borrarTodos();
    })            
    .then(()=>{
        return AgregarAPartir(lastChild);
    })
    .then(()=>{
        return EnviarDer();
    })
    .then(()=> {
        return AnimarIzq();
    });
    //.catch(fail);
}
function fail(){
    console.log("Error");
}
function AnimarIzq(){
    return new Promise(function(resolve, reject) { 
        for (var i=0;i< cardCont.children.length;i++){
             cardCont.children[i].style.visibility = '';
            var pos = document.body.offsetWidth -  cardCont.children[i].offsetLeft;            
             cardCont.children[i].style.transition = cssTransA;
             cardCont.children[i].style.transform = '';                                                    
        }
        setTimeout(resolve, timeoutCards);
    });
}
function AnimarDer(){
    return new Promise(function(resolve, reject) { 
        for (var i= cardCont.children.length-1;i>=0;i--){
             cardCont.children[i].style.visibility = '';
            var pos = document.body.offsetWidth -  cardCont.children[i].offsetLeft;            
             cardCont.children[i].style.transition = cssTransA;
             cardCont.children[i].style.transform = '';                                                    
        }
        setTimeout(resolve, timeoutCards);
    });
}        
function EnviarDer(){
    return new Promise(function(resolve, reject) { 
        for (var i=0;i< cardCont.children.length;i++){
            var pos = document.body.offsetWidth -  cardCont.children[i].offsetLeft;            
             cardCont.children[i].style.transition = '';
             cardCont.children[i].style.transform = 'translateX(' + pos + 'px)';                                    
        }
        resolve();                                
    });
}
function EnviarIzq(){
    return new Promise(function(resolve, reject) { 
        for (var i=0;i< cardCont.children.length;i++){
            var pos = -  cardCont.children[i].offsetLeft;
             cardCont.children[i].style.transition = '';
             cardCont.children[i].style.transform = 'translateX(' + pos + 'px)';                                    
        }
        resolve();                                
    });
}        
function AgregarAPartir(c){            

    return new Promise(function(resolve, reject) { 
        for(i=0;i<cardsT.length;i++)
            if(cardsT[i].innerHTML==c.innerHTML)
                break;
        i++;
        if(i==cardsT.length)    i=0;
        while(i<cardsT.length){
            var node = cardsT[i].cloneNode(true);
            if(encaj()  ) {             //fit ?
                node.style.visibility = 'hidden';
                 cardCont.appendChild(node);                         
            }
            else
                break;
            i++;
        } 
        setTimeout(resolve, 0);
    });            
}        
function AgregarAAntes(c){            
    return new Promise(function(resolve, reject) { 
        var prim=false;

        for(i=0;i<cardsT.length;i++)
            if(cardsT[i].innerHTML==c.innerHTML)
                break;
        i--;
        if(i==-1)   i=cardsT.length-1;
        while(i>=0){
            var node = cardsT[i].cloneNode(true);
            var nodeAnt;
            if(encaj()  ) {             //fit ?
                node.style.visibility = 'hidden';
                if(prim)
                     cardCont.appendChild(node);        
                else{                            
                     cardCont.insertBefore(node, nodeAnt);
                }
                nodeAnt = node;                        
            }
            else
                break;
            i--;
        } 
        setTimeout(resolve, 0);
    });            
}        
function borrarTodos(){

    return new Promise(function(resolve, reject) { 
        while( cardCont.firstElementChild) {                    
             cardCont.removeChild( cardCont.firstElementChild);                     
        }                
        resolve();
    });

}
function AnimarBorrar(signo){
    return new Promise(function(resolve, reject) { 
        var j=0;                        
        while(j< cardCont.children.length )            {                
             cardCont.children[j].style.transform = 'translateX(' + signo + '100vw)';
             cardCont.children[j].style.transition = cssTransB;    
            j++;
        }                
        //console.log(new Date().toLocaleString());
        setTimeout(resolve, timeoutCards);            
    });
}

function getTotal (){
    //Ancho total de los  cardContcards-item en la pag
    var total = 0;            
    var child =  cardCont.children;             
    for (var i = 0; i < child.length; i++)                                 
        total += child[i].offsetWidth;            
    return total;
}
function encaj(p){            
    return ((getTotal() + cardWith) < (document.body.offsetWidth )  ) ;
}
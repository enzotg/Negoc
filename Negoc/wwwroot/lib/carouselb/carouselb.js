
function carouselbSiguiente(carId){
    carId = "#" + carId + " ";
    let arr = document.querySelectorAll(carId + ".carouselb-item");
    let prim = arr[0];        
    let aux = prim.cloneNode(true);
    let transPor = '-100% - ' + getComputedStyle(document.querySelector(".carouselb-item")).marginLeft +
        ' - ' + getComputedStyle(document.querySelector(".carouselb-item")).marginRight;

    if(document.querySelectorAll(carId + ".carouselb-item[data-id='" +  aux.getAttribute("data-id") +  "']").length > 1)   return;
    
    document.querySelector(carId + ".carouselb-inner").appendChild(aux);            
    arr = document.querySelectorAll(carId + ".carouselb-item");
    
    setTimeout(function() {
        arr.forEach(function(value) {                
            value.style.transition = '.5s';
            value.style.transform = 'translateX(calc(' + transPor + '))'; 
        });
    }, 10);
    setTimeout (function() {            
        arr.forEach(function(value) {                
            value.style.transition = '';
            value.style.transform = 'translateX(0%)'; 
        });            
        arr[0].remove();    
    },500);
}

function carouselbAnterior(carId){
    carId = "#" + carId + " ";
    let arr = document.querySelectorAll(carId + ".carouselb-item");
    let prim = arr[arr.length-1];        
    let aux = prim.cloneNode(true);        
    let transPor = '-100% - ' + getComputedStyle(document.querySelector(".carouselb-item")).marginLeft +
        ' - ' + getComputedStyle(document.querySelector(".carouselb-item")).marginRight;

    if(document.querySelectorAll(carId + ".carouselb-item[data-id='" +  aux.getAttribute("data-id") +  "']").length > 1)  return;
            
    document.querySelector(carId + ".carouselb-inner").insertBefore(aux, arr[0]);                    
    arr = document.querySelectorAll(carId + ".carouselb-item");

    arr.forEach(function(value) {            
        value.style.transition = '';
        //value.style.transform = 'translateX(-100%)';
        value.style.transform = 'translateX(calc(' + transPor + '))'; 
    });
    
    setTimeout(function() {            
        arr.forEach(function(value) {                
            value.style.transition = '.5s';
            value.style.transform = 'translateX(0%)'; 
        });            
    }, 10);        
    setTimeout (function() {
        arr[arr.length-1].remove();
    },500);        
}

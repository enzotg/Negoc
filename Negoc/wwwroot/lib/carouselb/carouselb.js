function carouselbSiguiente(){
    let arr = document.querySelectorAll(".carouselb-item");
    let prim = arr[0];        
    let aux = prim.cloneNode(true );        

    if(document.querySelectorAll(".carouselb-item[data-id='" +  aux.getAttribute("data-id") +  "']").length > 1)   return;
    
    document.querySelector(".carouselb-inner").appendChild(aux);            
    arr = document.querySelectorAll(".carouselb-item");
    
    setTimeout(function() {
        arr.forEach(function(value, index) {                
            value.style.transition = '.5s';
            value.style.transform = 'translateX(-100%)'; 
        });
    }, 10);
    setTimeout (function() {            
        arr.forEach(function(value, index) {                
            value.style.transition = '';
            value.style.transform = 'translateX(0%)'; 
        });            
        arr[0].remove();    
    },500);
}

function carouselbAnterior(){
    let arr = document.querySelectorAll(".carouselb-item");
    let prim = arr[arr.length-1];        
    let aux = prim.cloneNode(true);        

    if(document.querySelectorAll(".carouselb-item[data-id='" +  aux.getAttribute("data-id") +  "']").length > 1)  return;
            
    document.querySelector(".carouselb-inner").insertBefore(aux, arr[0]);                    
    arr = document.querySelectorAll(".carouselb-item");

    arr.forEach(function(value, index) {            
        value.style.transition = '';
        value.style.transform = 'translateX(-100%)';
    });
    
    setTimeout(function() {            
        arr.forEach(function(value, index) {                
            value.style.transition = '.5s';
            value.style.transform = 'translateX(0%)'; 
        });            
    }, 10);        
    setTimeout (function() {
        arr[arr.length-1].remove();
    },500);        
}

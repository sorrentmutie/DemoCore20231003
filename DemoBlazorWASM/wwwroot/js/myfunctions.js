window.firstFunction = function (a,b,c) {
    var somma = a + b + c;
    console.log(somma);
    return somma;
}

window.secondFunction = (name) => {
    console.log("Hello, " + name);
}


window.thirdFunction = () => {
    DotNet.invokeMethodAsync('LibreriaComponentiBlazor', 'RestituisciArrayAsync')
        .then(data => {
            console.log(data);
        });
}

window.fourthFunction = (instanceOfCSharpObject) => {
    instanceOfCSharpObject.invokeMethodAsync('SayHello')
        .then(r => console.log(r));
}

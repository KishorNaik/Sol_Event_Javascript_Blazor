export function initializeCounterComponent(buttonElement) {
    console.log(buttonElement.id);

    $(buttonElement).click(function (e) {
        console.log(e.target);

        let valueTarget = `Hello ${e.target.nodeName}| id :${e.target.id}`;
        console.log(valueTarget);
        //$(this).html(valueTarget);
    });
}
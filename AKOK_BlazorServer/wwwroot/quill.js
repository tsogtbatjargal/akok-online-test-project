var quill;
function initializeQuill() {
    quill = new Quill('#editor', {
        theme: 'snow'
    });

    quill.on('text-change', function () {
        var longText = document.querySelector('#longText');
        console.log('hidden input value before update:', longText.value);
        longText.value = quill.root.innerHTML;
        console.log('hidden input value after update:', longText.value);
    });
}

function setQuillContent(content) {
    console.log('setQuillContent called with content:', content);
    if (quill) {
        quill.root.innerHTML = content;
        var longText = document.querySelector('#longText');
        console.log('hidden input value:', longText.value);
        longText.value = content;
    }
}

//function setQuillContent(content) {
//    if (quill) {
//        quill.root.innerHTML = content;
//        var longText = document.querySelector('input[type=hidden]');
//        longText.value = content;
//        console.log('hidden input value:', longText.value);
//    }
//}
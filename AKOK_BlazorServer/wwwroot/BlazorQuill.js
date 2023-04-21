(function () {
    window.QuillFunctions = {
        createQuill: function (quillElement) {
            var options = {
                debug: 'info',
                modules: {
                    toolbar: '#toolbar'
                },
                placeholder: 'Compose an epic...',
                readOnly: false,
                theme: 'snow'
            };
            // set quill at the object we can call
            // methods on later
            new Quill(quillElement, options);

            // create a new Quill editor instance and store it in the __quill property of the passed element
            /*quillElement.__quill = new Quill(quillElement, options);*/
        },
        getQuillContent: function (quillControl) {
            return JSON.stringify(quillControl.__quill.getContents());
        },
        getQuillText: function (quillControl) {
            return quillControl.__quill.getText();
        },
        getQuillHTML: function (quillControl) {
            return quillControl.__quill.root.innerHTML;
        },
        loadQuillContent: function (quillControl, quillContent) {
            content = JSON.parse(quillContent);
            return quillControl.__quill.setContents(content, 'api');
        },
        disableQuillEditor: function (quillControl) {
            var toolbar = quillControl.parentElement.querySelector('.ql-toolbar');
            quillControl.__quill.enable(false);
            toolbar.setAttribute('disabled', 'true');            
        },
        enableQuillEditor: function (quillControl) {
            /*var toolbar = quillControl.parentElement.querySelector('.ql-toolbar');*/
            quillControl.__quill.enable(true);
            /*toolbar.setAttribute('disabled', 'true');*/ 
            window.location.reload();
        }
    };
})();
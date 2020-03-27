$(function () {
    $.validator.addMethod("requiredifnot", function (value, element, param) {
        var target = $(element.form).find('[name='+param.propertyname+']')[0];
        var val = (this.checkable(target)) ? $(target).is(":checked").toString() : $(target).val().toString().toLowerCase();
        if (val.toLowerCase() !== param.propertyvalue.toLowerCase()) {
            if (!this.depend(param, element))
                return "dependency-mismatch";
            switch (element.nodeName.toLowerCase()) {
                case 'select':
                    var val = $(element).val();
                    return val && val.length > 0;
                case 'input':
                    if (this.checkable(element))
                        return this.getLength(value, element) > 0;
                    if (element.type === "file")
                        return element.files.length > 0;
                default:
                    if ($(element).inputmask)
                        value = $(element).inputmask('unmaskedvalue');
                    return $.trim(value).length > 0;
            }
        }

        return true;
    });


    $.validator.unobtrusive.adapters.add("requiredifnot", ["targetpropertyname", "targetpropertyvalue"], function (options) {
        if ((options.element.tagName.toUpperCase() !== "INPUT" && options.element.tagName.toUpperCase() !== "SELECT") || options.element.type.toUpperCase() !== "CHECKBOX") {
            options.rules["requiredifnot"] = {
                propertyname: options.params.targetpropertyname,
                propertyvalue: options.params.targetpropertyvalue
            };
            options.messages["requiredifnot"] = options.message;
        }
    });
}(jQuery));
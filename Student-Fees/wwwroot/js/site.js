// Validating and submiting forms.
(function () {
    'use strict';
    window.addEventListener('load', function () {
        var forms = document.getElementsByClassName('needs-validation');
        var validation = Array.prototype.filter.call(forms, function (form) {
            form.addEventListener('submit', function (event) {
                event.preventDefault();
                event.stopPropagation();
                if (form.checkValidity() === true) {
                    // Serialise and stringify the form.
                    var serialisedForm = {};
                    $.each($(event.target).serializeArray(), function (index, item) {
                        serialisedForm[item.name] = item.value;
                    });

                    // Handle CSRF token.
                    var csrfToken = serialisedForm.__RequestVerificationToken;
                    delete serialisedForm.__RequestVerificationToken;

                    // Send an ajax POST request to create the new payment object.
                    $.ajax({
                        method: 'POST',
                        contentType: 'application/json',
                        url: '/payment',
                        data: JSON.stringify(serialisedForm),
                        headers: {
                            'X-CSRF-TOKEN': csrfToken
                        }
                    }).done(function (response) {
                        location.reload();
                    }).fail(function (jqXHR, textStatus) {
                        if (jqXHR.responseJSON !== null) {
                            $.each(jqXHR.responseJSON, function (index, errors) {
                                var errorString = '';
                                $.each(errors, function (index, error) {
                                    errorString += '<p>' + error + '</p>';
                                });
                                alert(errorString);
                            });
                        }
                    });
                }
                form.classList.add('was-validated');
            }, false);
        });
    }, false);
})();
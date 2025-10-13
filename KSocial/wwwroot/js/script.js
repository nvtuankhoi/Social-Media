if (localStorage.theme === 'dark' || (!('theme' in localStorage) && window.matchMedia('(prefers-color-scheme: dark)').matches)) {
    document.documentElement.classList.add('dark')
    } else {
    document.documentElement.classList.remove('dark')
    }

localStorage.theme = 'light'

localStorage.theme = 'dark'

localStorage.removeItem('theme')




document.addEventListener('DOMContentLoaded', function () {
    var addPostUrl = document.getElementById('addPostUrl');
    if (addPostUrl) {
        addPostUrl.addEventListener('change', function () {
            if (this.files[0]) {
                var picture = new FileReader();
                picture.readAsDataURL(this.files[0]);
                picture.addEventListener('load', function (event) {
                    document.getElementById('addPostImage').setAttribute('src', event.target.result);
                    document.getElementById('addPostImage').style.display = 'block';
                });
            }
        });
    }
});




document.addEventListener('DOMContentLoaded', function () {
    var createStatusUrl = document.getElementById('createStatusUrl');
    if (createStatusUrl) {
        createStatusUrl.addEventListener('change', function () {
            if (this.files[0]) {
                var picture = new FileReader();
                picture.readAsDataURL(this.files[0]);
                picture.addEventListener('load', function (event) {
                    document.getElementById('createStatusImage').setAttribute('src', event.target.result);
                    document.getElementById('createStatusImage').style.display = 'block';
                });
            }
        });
    }
});



document.addEventListener('DOMContentLoaded', function () {
    var createProductUrl = document.getElementById('createProductUrl');
    if (createProductUrl) {
        createProductUrl.addEventListener('change', function () {
            if (this.files[0]) {
                var picture = new FileReader();
                picture.readAsDataURL(this.files[0]);
                picture.addEventListener('load', function (event) {
                    document.getElementById('createProductImage').setAttribute('src', event.target.result);
                    document.getElementById('createProductImage').style.display = 'block';
                });
            }
        });
    }
});









    
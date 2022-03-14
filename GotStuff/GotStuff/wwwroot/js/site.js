////$('#myModal').on('shown.bs.modal', function () {
////    $('#myInput').trigger('focus')
////})

const checkbox = document.getElementById('checkbox');

checkbox.addEventListener('change', () => {
    document.body.classList.toggle('dark');
})
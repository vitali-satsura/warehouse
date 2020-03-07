let value;
const link = document.getElementById('employees-link');
const input = document.getElementById('position-input');

document.getElementById('position-input').addEventListener('change', (event) => {
    value = input.value;
    link.href = `/home/GetEmployeesByPosition?posName=${value}`;
});
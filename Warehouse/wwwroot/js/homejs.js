let positionValue;
const EmployeesLink = document.getElementById('employees-link');
const positionInput = document.getElementById('position-input');

positionInput.addEventListener('change', () => {
    positionValue = positionInput.value;
    EmployeesLink.href = `/home/GetEmployeesByPosition?posName=${positionValue}`;
});

//document.querySelector('.employees-link-container').addEventListener('click', () => {
//    if (!positionValue) {
//        document.querySelector('.position-danger').innerText = 'Enter position';
//    }
//});

let typeValue;
const productsLink = document.getElementById('products-link');
const typeInput = document.getElementById('type-input');

typeInput.addEventListener('change', () => {
    typeValue = typeInput.value;
    productsLink.href = `/home/GetProductByType?type=${typeValue}`;
});

const startDate = document.getElementById('orders-date-start');
const endDate = document.getElementById('orders-date-end');
const ordersLink = document.getElementById('orders-link');
let startDateValue;
let endDateValue;

startDate.addEventListener('change', () => {
    startDateValue = startDate.value;
    ordersLink.href = `/home/GetOrdersByDate?startDateString=${startDateValue}&endDateString=${endDateValue}`;
    console.log(ordersLink.href);
});

endDate.addEventListener('change', () => {
    endDateValue = endDate.value;
    ordersLink.href = `/home/GetOrdersByDate?startDateString=${startDateValue}&endDateString=${endDateValue}`;
    console.log(ordersLink.href);
});

ordersLink.addEventListener('click', () => {
    if (!startDateValue || !endDateValue) {
        ordersLink.href = '#';
    }
});
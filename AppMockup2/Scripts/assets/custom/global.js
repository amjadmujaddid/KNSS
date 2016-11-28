function toDate1(date) {
    var sqlDate = "";

    var dateString = String(date);

    var day = dateString.substr(8, 2);
    var month = dateString.substr(5, 2);
    var year = dateString.substr(0, 4);

    sqlDate = day + "-" + month + "-" + year;

    return sqlDate;
}

function phoneToSubmit (phone_number) {
	var desired = phone_number.replace(/[-_\s]/g, '');
	return desired;
}
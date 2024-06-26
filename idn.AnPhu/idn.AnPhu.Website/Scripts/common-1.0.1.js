var __app = {};
$(document).ajaxStart(function () {
	if ($("#loading123_").length == 0) {
		var div = $("<div id='loading123_' style='position:fixed; top:0; right:0; width:120px; height:30px; background:#e00; padding-left:20px;'/>");
		div.html("<span style='color:#fff; font: 700 12px/30px arial;'>loading...</span>");
		div.appendTo('body');
	}
	$("#loading123_").fadeIn();
});


$(document).ajaxStop(function () {
	$("#loading123_").hide();
});


window.onerror = function (errorMeaage, fileName, lineNumber) {
	__globalerror = 1;
	var c = 'Script error: ' + errorMeaage + '\nFileName: ' + fileName + '\nLine no: ' + lineNumber;
	alert(c);
	$("#loading123_").hide();

}

function processAjaxForm(form) {



	var ajaxFormParam = {
		async: true,
		dataType: 'json',
		beforeSend: function () {
			var form = $(this);

			form.find("[type=submit]").addClass("disabled").attr("disabled", true);
		},
		beforeSubmit: function (arr, $form, options) {

			if (!$form.valid()) {
				return false;
			}
		},
		success: function (response, statusText, xhr, $form) {
			onSumitSuccess.call(this, response, statusText, xhr, $form)
		},
		error: function () {
			var form = $(this);
			form.find("[type=submit]").removeClass('disabled').removeAttr('disabled');
			alert('error ');
		}
	};



	form.submit(function () {
		// reset all the validation messer elements. (Change for textContent form.)
		form.find('.field-validation-error').empty();

		if (!form.valid()) {

			if (form.find('.tabs').length) {
				var selector = 'input.input-validation-error,select.input-validation-error';
				form.find(selector).parents('div.tab-content')
						.each(function () {
							var tab = $(this);
							var li = $('a[href="#' + tab.attr('id') + '"]')
							.hide().show('pulsate', {}, 100)
							.show('highlight', {}, 200)
							.show('pulsate', {}, 300)
							.show('highlight', {}, 400);
						});
			}
		}
	});


	if (!form.hasClass('no-ajax')) {
		form.ajaxForm(ajaxFormParam);
		form.submit(function () {

		}
		);
	}



}


function showAjaxFormDialog(url, title, opt) {

	var div = $('<div style="display:none; "></div>').appendTo('body');

	var options = {

		width: 650,
		height: 500,
		modal: true,
		buttons: [
					{
						text: "Đóng",
						click: function () {

							$(this).dialog("close");


						}
					},
					{
						text: "Lưu",
						"class": 'submit',
						click: function () {
							div.find('form').eq(0).submit();

						}
					}
		],

		close: function () { },
		ready: function () { },

	};


	$.extend(true, options, opt);



	var dialog = div.dialog({
		width: options.width,
		dialogClass: options.dialogClass,
		height: options.height,
		title: title,
		autoOpen: false,
		modal: options.modal,
		close: function () { options.close(); div.remove(); },

		buttons: options.buttons

	});


	dialog.dialog("open");


	$.ajax(
	 {
	 	type: "GET",
	 	url: url,
	 	dataType: "html",

	 	success: function (data, status) {
	 		if (data.length > 0) {
	 			div.html(data);
	 			var form = div.find('form');
	 			if (form.length > 0) {
	 				processAjaxForm(form.eq(0));
	 			}

	 			options.ready();
	 		}
	 	},
	 	error: function (e) {
	 		
	 	}
	 });

	return dialog;

}





function showAjaxDialog(url, title, opt) {

	

	var options = {

		width: 650,
		height: 500,
		modal: true,
		buttons: [
					{
						text: "Đóng",
						click: function () {

							$(this).dialog("close");


						}
					},
		],

		close: function () { },
		ready: function () { },
		error: function () { },

	};


	var div = $('<div style="display:none; "></div>').appendTo('body');

	$.extend(true, options, opt);



	var dialog = div.dialog({
		width: options.width,
		dialogClass: options.dialogClass,
		height: options.height,
		title: title,
		autoOpen: false,
		modal: options.modal,
		close: function () { options.close();},

		buttons: options.buttons

	});


	dialog.dialog("open");


	$.ajax(
	 {
	 	type: "GET",
	 	url: url,
	 	dataType: "html",

	 	success: function (data, status) {
	 		if (data.length > 0) {
	 			div.html(data);
	 			options.ready();
	 		}
	 	},
	 	error: function (e) {
	 		options.error(e);
	 	}
	 });

	return dialog;

}
﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$('#uploadProgress').hide();
$('#fg-y').hide();

$(document).ready(function(){
	$('#uploadForm').on('submit',function(e){
		e.preventDefault();
		url = $(this).attr('action');
		type = "POST";
		
		let fileExtensions = ['.xls','.xlsx'];
		let fname = $('#ff').val();
		
		if(fname.length == 0){
			alert("Please select a file");
			return false;
		}
		else{
			let ext = fname.replace(/^.*\./,'.');
			console.log(ext);
			if($.inArray(ext,fileExtensions) == -1){
				alert("Please select an Excel file");
			    return false;
			}
		}
		
		dt = new FormData($(this));
		let xxx = $('input[name="__RequestVerificationToken"]').val();
		dt.append("__RequestVerificationToken",xxx);
		dt.append("ff",$('#ff')[0].files[0]);
		
		$('#uploadProgress').fadeIn();
		$.ajax({
			url: url,
			type: type,
			data: dt,
			
			cache: false,
			contentType: false,
			processData: false,
			
			xhr: function(){
				var myXHR = $.ajaxSettings.xhr();
				
				if(myXHR.upload){
					myXHR.upload.addEventListener('progress',function(e){
						if(e.lengthComputable){
							$('#uploadProgress').attr({
								value: e.loaded,
								max: e.total
							});
						}
					}, false);
				}
				
				return myXHR;
			},
			
			success: function(response){
				if(response.length == 0) alert("An unknown error occured while uploading the file");
				
				else{
					$('#uploadProgress').hide();
					$('#logs').html(response);
				}
			},
			error: function(e){
				$('#logs').html(e.responseText);
			}
		});
	})
	
	$('#qtype').change(function(e){
		e.preventDefault();
		let qtype = $(this).val();
		
		if(qtype == "total" || qtype == "none"){
			$('#fg-y').hide();
		}
		else if(qtype == "comparison"){
			$('#fg-y').fadeIn();
		}
	});
});

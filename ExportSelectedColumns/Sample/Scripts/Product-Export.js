;
(function (windows) {
    if (typeof (jQuery) === 'undefined') { alert('jQuery Library NotFound.'); return; }

    var HasData = 'False';

    $(function () {

        //顯示匯出選項視窗
        $('#ButtonExport').click(function () {
            $('#ExportDataDialog').modal('show');
        });

        $('#SelectAllColumns').unbind('click').click(function () {
            //選取全部欄位
            $('input:checkbox[name=Checkbox_ExportColumns]').prop('checked', 'checked');
        });

        $('#UnselectAllColumns').unbind('click').click(function () {
            //不選取全部欄位
            $('input:checkbox[name=Checkbox_ExportColumns]').removeAttr('checked');
        });

        //匯出資料
        $('#ButtonExecuteExport').click(function () {
            //匯出 Excel 檔名
            var exportFileName = $.trim($('#ExportFileName').val());

            //匯出的資料欄位
            var selectedColumns = $('input:checkbox[name=Checkbox_ExportColumns]:checked').map(function () {
                return $(this).val();
            }).get().join(',');

            if (selectedColumns.length == 0) {
                alert("必須選取匯出資料的欄位.");
                return false;
            }

            ExportData(exportFileName, selectedColumns);
        });

    });

    function ExportData(exportFileName, selectedColumns) {
        /// <summary>
        /// 資料匯出
        /// </summary>

        $.ajax({
            type: 'post',
            url: Router.action('Product', 'HasData'),
            dataType: 'json',
            cache: false,
            async: false,
            success: function (data) {
                if (data.Msg) {
                    HasData = data.Msg;
                    if (HasData == 'False') {
                        alert("尚未建立任何資料, 無法匯出資料.");
                    }
                    else {
                        window.location = exportFileName.length == 0
                            ? Router.action('Product', 'Export', { selectedColumns: selectedColumns })
                            : Router.action('Product', 'Export', { fileName: exportFileName, selectedColumns: selectedColumns });

                        $('#ExportFileName').val('');
                        $('#ExportDataDialog').modal('hide');
                    }
                }
            },
            error: function (xhr, textStatus, errorThrown) {
                alert("資料匯出錯誤");
            }
        });
    }
})
(window);
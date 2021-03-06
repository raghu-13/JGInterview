﻿function LoadDesignationUsers(DesigIds) {
    if (DesigIds == 0 || DesigIds == undefined) {
        DesigIds = "";
    }

    //Set Params
    sequenceScopeTG.UserSelectedDesigIds = DesigIds;

    //Call Data Function
    sequenceScopeTG.getUserByDesignation();
}

function LoadSubTasks() {

    //Set Params
    sequenceScopeTG.UserSelectedDesigIds = "";

    //Get Page Size
    var pageSize = $('#drpPageSize').val();
    if (pageSize == undefined)
        pageSize = 5;
    sequenceScopeTG.pageSize = pageSize;

    sequenceScopeTG.getSubTasks();
    sequenceScopeTG.getAssignUser();
}

function SetChosenAssignedUsers() {
    $('*[data-chosen="1"]').each(function (index) {

        var dropdown = $(this);

        if (dropdown.attr("data-assignedusers")) {
            var assignedUsers = JSON.parse("[" + dropdown.attr("data-assignedusers") + "]");
            $.each(assignedUsers, function (Index, Item) {
                dropdown.find("option[value='" + Item + "']").prop("selected", true);
            });
        }

        $(this).chosen();
        $(this).trigger('chosen:updated');

        setSelectedUsersLink();
    });
}

function EditAssignedSubTaskUsers(sender) {

    var $sender = $(sender);
    var intTaskID = parseInt($sender.attr('data-taskid'));
    var intTaskStatus = parseInt($sender.attr('data-taskstatus'));
    var arrAssignedUsers = [];
    var arrDesignationUsers = [];
    var options = $sender.find('option');

    $.each(options, function (index, item) {

        var intUserId = parseInt($(item).attr('value'));

        if (intUserId > 0) {
            arrDesignationUsers.push(intUserId);
            //if ($.inArray(intUserId.toString(), $(sender).val()) != -1) {                
            //    arrAssignedUsers.push(intUserId);
            //}
            if ($(sender).val() == intUserId.toString()) {
                arrAssignedUsers.push(intUserId);
            }
        }
    });

    SaveAssignedTaskUsers();


    function SaveAssignedTaskUsers() {
        ShowAjaxLoader();

        var postData = {
            intTaskId: intTaskID,
            intTaskStatus: intTaskStatus,
            arrAssignedUsers: arrAssignedUsers,
            arrDesignationUsers: arrDesignationUsers
        };

        CallJGWebService('SaveAssignedTaskUsers', postData, OnSaveAssignedTaskUsersSuccess, OnSaveAssignedTaskUsersError);

        function OnSaveAssignedTaskUsersSuccess(response) {
            HideAjaxLoader();
            if (response) {
                HideAjaxLoader();
                LoadSubTasks();
            }
            else {
                OnSaveAssignedTaskUsersError();
            }
        }

        function OnSaveAssignedTaskUsersError(err) {
            HideAjaxLoader();
            //alert(JSON.stringify(err));
            alert('Task assignment cannot be updated. Please try again.');
        }
    }
}

function updateMultiLevelChild(tid, desc, autosave) {
    if (desc != '' && desc != undefined) {
        if (autosave)
            ShowAutoSaveProgress(pid);
        else
            ShowAjaxLoader();

        var postData = {
            tid: tid,
            Description: desc
        };

        $.ajax({
            url: '../../../WebServices/JGWebService.asmx/UpdateTaskDescriptionChildById',
            contentType: 'application/json; charset=utf-8;',
            type: 'POST',
            dataType: 'json',
            data: JSON.stringify(postData),
            asynch: false,
            success: function (data) {                

                if (!autosave) {
                    $('#ChildEdit' + tid).html(desc);
                    isadded = false;
                    HideAjaxLoader();
                    alert('Updated Successfully.');
                }
                else {
                    HideAutoSaveProgress(pid);
                }
            },
            error: function (a, b, c) {
                HideAjaxLoader();
            }
        });
    }
}

function OnSaveSubTask(taskid, desc) {

    var installID = $('#listId' + taskid).attr('data-listid');
    var TaskLvl = $('#nestLevel' + taskid).val();
    var Class = $('#listId' + taskid).attr('data-label');

    if (desc != undefined && desc.trim() != '') {

        ShowAjaxLoader();
        if (TaskLvl == '') TaskLvl = 1;

        var postData = {
            ParentTaskId: taskid,
            InstallId: installID,
            Description: desc,
            IndentLevel: TaskLvl,
            Class: Class
        };

        CallJGWebService('SaveTaskMultiLevelChild', postData, OnAddNewSubTaskSuccess, OnAddNewSubTaskError);

        function OnAddNewSubTaskSuccess(data) {
            if (data.d == true) {
                PreventScroll = 1;
                alert('Task saved successfully.');
                LoadSubTasks();
            }
            else {
                alert('Task cannot be saved. Please try again.');
            }
        }

        function OnAddNewSubTaskError(err) {
            alert('Task cannot be saved. Please try again.');
        }
    }
    return false;

}

function ShowAutoSaveProgress(divid) {
    //$('#TaskloaderDiv' + divid).html('<img src="../../img/ajax-loader.gif" style="height:16px; vertical-align:bottom" /> Auto Saving...');
    $('#TaskloaderDiv' + divid).fadeIn(500);
}
function HideAutoSaveProgress(divid) {
    $('#TaskloaderDiv' + divid).fadeOut(500);
    //$('#TaskloaderDiv' + divid).html('');
}
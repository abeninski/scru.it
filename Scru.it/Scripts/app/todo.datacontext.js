window.todoApp = window.todoApp || {};

window.todoApp.datacontext = (function () {

    var datacontext = {
        getTodoLists: getTodoLists,
        createTodoList: createTodoList,
        saveNewTodoList: saveNewTodoList,
        deleteTodoList: deleteTodoList,
        saveChanged: saveChangedTodoList
    };

    return datacontext;

    function getTodoLists(todoListsObservable, errorObservable) {
        return ajaxRequest("get", todoListUrl())
            .done(getSucceeded)
            .fail(getFailed);

        function getSucceeded(data) {
            var mappedTodoLists = $.map(data, function (list) { return new createTodoList(list); });
            todoListsObservable(mappedTodoLists);
        }

        function getFailed() {
            errorObservable("Error retrieving todo lists.");
        }
    }

    function createTodoList(data) {
        return new datacontext.todoList(data); // todoList is injected by todo.model.js
    }

    function saveNewTodoList(todoList) {
        clearErrorMessage(todoList);
        return ajaxRequest("post", todoListUrl(), todoList)
            .done(function (result) {
                todoList.id = result.id;
                todoList.userId = result.userId;
            })
            .fail(function () {
                todoList.errorMessage("Error adding a new todo list.");
            });
    }

    function deleteTodoList(todoList) {
        return ajaxRequest("delete", todoListUrl(todoList.id))
            .fail(function () {
                todoList.errorMessage("Error removing todo list.");
            });
    }

    function saveChangedTodoList(todoList) {
        clearErrorMessage(todoList);
        return ajaxRequest("put", todoListUrl(todoList.id), todoList, "text")
            .fail(function () {
                todoList.errorMessage("Error updating the todo list title. Please make sure it is non-empty.");
            });
    }

    // Private
    function clearErrorMessage(entity) { entity.errorMessage(null); }
    function ajaxRequest(type, url, data, dataType) { // Ajax helper
        var options = {
            dataType: dataType || "json",
            contentType: "application/json",
            cache: false,
            type: type,
            data: data ? data.toJson() : null
        };
        var antiForgeryToken = $("#antiForgeryToken").val();
        if (antiForgeryToken) {
            options.headers = {
                'RequestVerificationToken': antiForgeryToken
            }
        }
        return $.ajax(url, options);
    }
    // routes
    function todoListUrl(id) { return "/api/posts/" + (id || ""); }

})();
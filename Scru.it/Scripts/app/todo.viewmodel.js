window.todoApp.todoListViewModel = (function (ko, datacontext) {
    /// <field name="todoLists" value="[new datacontext.todoList()]"></field>
    var todoLists = ko.observableArray(),
        error = ko.observable(),
        editItem = {
            title: ko.observable('new post')
            , description: ko.observable('new post description')
            , visualUrl: ko.observable('')
        },
        addPost = function () {
            var todoList = datacontext.createTodoList();
            todoList.title(editItem.title());
            todoList.description(editItem.description());
            todoList.visualUrl(editItem.visualUrl())

            datacontext.saveNewTodoList(todoList)
                .then(addSucceeded)
                .fail(addFailed);

            function addSucceeded() {
                showTodoList(todoList);
            }
            function addFailed() {
                error("Save of new todoList failed");
            }
        },
        showTodoList = function (todoList) {
            todoLists.unshift(todoList); // Insert new todoList at the front
        },
        deleteTodoList = function (todoList) {
            todoLists.remove(todoList);
            datacontext.deleteTodoList(todoList)
                .fail(deleteFailed);

            function deleteFailed() {
                showTodoList(todoList); // re-show the restored list
            }
        };

    datacontext.getTodoLists(todoLists, error); // load todoLists

    return {
        todoLists: todoLists,
        error: error,
        addPost: addPost,
        deleteTodoList: deleteTodoList,
        editItem: editItem
    };

})(ko, todoApp.datacontext);

// Initiate the Knockout bindings
ko.applyBindings(window.todoApp.todoListViewModel);

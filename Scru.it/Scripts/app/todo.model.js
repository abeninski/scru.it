(function (ko, datacontext) {
    datacontext.todoList = todoList;

    function todoList(data) {
        var self = this;
        data = data || {};

        // Persisted properties
        self.id = data.id;
        //self.userId = data.userId || "to be replaced";
        self.title = ko.observable(data.title || "My todos");
        self.visualUrl = ko.observable(data.visualUrl || "");
        self.description = ko.observable(data.description || "My descriptio");
        self.todos = new Array();
        self.errorMessage = ko.observable('');

        self.toJson = function () { return ko.toJSON(self) };
    };
    
})(ko, todoApp.datacontext);
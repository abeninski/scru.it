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
        self.screwYouCount = ko.observable(data.screwYouCount || 0);
        self.screwItCount = ko.observable(data.screwItCount || 0);
        self.errorMessage = ko.observable('');
        self.screwIt = function (d) {
            var currentCount = self.screwItCount()
            self.screwItCount(currentCount + 1);

            datacontext.saveChanged(self);
        }

        self.screwYou = function (d) {
            var currentCount = self.screwYouCount()
            self.screwYouCount(currentCount + 1);

            datacontext.saveChanged(self);
        }

        self.toJson = function () { return ko.toJSON(self) };
    };
    
})(ko, todoApp.datacontext);
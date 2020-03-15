const localization: Record<string, string>  = {
    //--
    //-- general labels
    //-- 
    "general.copyright": "marqueone © 2019 AOT - Test",
    "general.name": "groupr",
    "general.search": "Search",
    "general.no-description": "No Description",
    "general.title": "Welcome to Groupr",
    "general.description": "Groupr allows you to create, and join any number of groups created by users!",
    "general.my-groups": "My Groups",
    "general.create-group":"Create Group",
    "general.view": "View",
    "general.join-group": "Join Group",
    "general.cancel": "Cancel",
    "general.label.name": "Name",
    "general.label.description": "Description",

    "create.title": "Create Group",
    "create.description": "Create a new group for users to join!",
    "create": "Create",
    "create.success.title": "Group Created!",
    "create.success.description": "Your Group: ${payload.name} was successfuly created",


    "error.name": "Name is a required field",
    "error.name.length": "Name can't be any larger than 64 characters",
    "error.description.length": "Description can't be any larger than 256 characters",


    //-- 
    //-- admin labels
    //-- 

    //--
    //-- errors
    //-- 
    "error.401.heading": "Unauthorized",
    "error.401.message": "Sorry, you are not authorized to view this content.",
    "error.404.heading": "Page Not Found",
    "error.404.message": "Sorry, but the page you are looking for has note been found. Try checking the URL for error, then hit the refresh button on your browser or try found something else in our app.",
    "error.500.heading": "Unexpected Error Occured",
    "error.500.message": "The server encountered something unexpected that didn't allow it to complete the request.",
};

export default localization;
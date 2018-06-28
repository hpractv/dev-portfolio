# Redux

 * Store - An object that stores the state of your application over time.  It's designed to handle the dispatch of requests to the state reducers.

 * Actions - A set of prescribed activities that are understood by the state reducer. Each action is characterized by a verb type, the current state, and possibly any data that is used to alter the state for the given action.

```json
 "action" : {
    "type" : "[ACT_ON_STATE]",
    "data" : { "value" : [VALUE] }
 }
```

* Reducers - A function that takes the current state and a dispatched action from the store and executes a prescribed operation on or based on the current state.  The return value is a new state.

    If no state is given, and initial default state is returned.  If the action doesn't require alteration of the current state, it is often returned as a result after the action is processed.

 * Async - Async processes can be handled by setting up the store to process 3 different actions.  The initiation of the async request, the successful return of the action, and the possibility of an error or a time out result.

    ```js
    const asyncRequest = { "type": "EXECUTE_ASYNC"};
    const asyncRequestError = { "type": "EXECUTE_ASYNC_FAILED", "result": "Error Message" };
    const asyncRequestSuccess = { "type": "EXECUTE_ASYNC_SUCCESS", "result": "Success" };
    ```

    Then a mapping to Redux store `dispatch` method can be wrapped in a JavaScript `Promise` object:

    ```c
    executeAsync = () => {
        var asyncPromise = Promise((success, error) => {
            var result = dispatch(asyncRequest);
            if(result == 'Success'){
              success(result);
            }else{
                error(result);
                return;
            }
        );
        
        asyncPromise
            .then(success => alert('Action Success'))
            .catch(error => alert(`Error{error.result}`);
    }

    ```

    This allows for an `async/await` pattern that allows for time to elapse while the dispatch call is being handled by the store.  If the processing requires any type of waiting period, the process will wait for the process to return before executing any further operations.

 * Middleware - Redux allows for different packages and extensions to be injected in the execution path of the store actions; either prior or post the reducer processing call.  This allows for general override or enhancements that can be introduced without altering the Reducer definition.  For instance, a state console logger could be used to see what the state of the store is at before and after any reducer call.

 * React
    * connect - A method that maps the React component props into the appropriate Redux store state.  This makes  it so the props object can be passed into the dispatch without having to build a new state object with every action attempt.

    * mapStateToProps - This method is used to create a React props object for use React component usage from a Redux state object.

    * mapDispatchToProps - This function maps React actions that require state update/modification to the dispatch method of the Redux store. This separates the UI display logic from the store state processing.

    * Provider - This is an object that is designed to connect the React props to the Redux store, without having to custom write the interface between the two-state object handlers.  It provides a way to define a conduit that transforms Redux state into React props.
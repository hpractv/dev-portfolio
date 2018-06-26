#Redux

 * Store - An object that stores the state of your application over time.  It's designed to handle the dispatch of requests to the state reducers.

 * Actions - A set of prescribed activities that are understood by the state reducer. Each action is characterized by a verb type, the current state, and possibly any data that is used to alter the state for the given action.

```json
 "action" : {
    "type" : "[ACT_ON_STATE]",
    "data" : { "value" : [VALUE] }
 }
```

* Reducers - A function that takes the current state and a dispatched action from the store and executes a prescribed operation on or based on the current state.  The return value is a new state.

    If no state is given, and initial default state is returned.  If the action doesn't require alteration of the current state, it is returned as a result after the action is processed.

 * Async - Async processes can be handled by the store processing 3 different actions.  The initiation of the async request, the successful return of the action, and the possibility of an error or timed out result.

```js

const asyncRequest = { "type": "EXECUTE_ASYNC"};
const asyncRequestError = { "type": "EXECUTE_ASYNC_FAILED", "result": "Error Message" };
const asyncRequestSuccess = { "type": "EXECUTE_ASYNC_SUCCESS", "result": "Success" };



```

 * Middleware
 * React
    * connect
    * mapStateToProps
    * mapDispatchToProps
    * Provider
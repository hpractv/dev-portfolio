 React

 React is a JavaScript Framework that allows for built-in state and property management of "classes" to be handled on the client-side.  It is also capable of automating state updates when component controls are properly mapped to the state containers.

 * Components - self contained element that handles its own rendering/display, state, and property marshalling.

 * Lifecycle Methods
    * `componentDidMount()`
        * A framework default event that gets called after the component has been rendered
        * Useful for setting any base state vars or settings for the component
    * `componentWillUnmount()`
        * A framework default event that gets called just before the component is disposed
        * Useful for taking down anything that's not needed beyond a particular component's lifecycle

 * State
    * The memory space that's local to the component
    * <u>State should never be set by attribute references (`this.state.[attribute] = value`).</u> It should always be set via the `setState()` method (`this.setState({ attribute: value })`).  This is the mechanism that React uses to decide whether or not it needs to re-render some parts or all of the virtual DOM.


 * Props
    * Attributes available to calling components
    * These attributes allow objects and values to be passed into the component, and be acted upon. Props are read-only

 * PropTypes
    * React library that exposes data validators for props specified
    * For example a prop of `Age` on the component `Person` could specified in the `PersonProps` interface.<br/><br/>
    A `Person` class extension similar to a javascript prototype could specify that age is a number:
    ```js
    Person.propTypes = {
        Age: PropTypes.number
    }
    ```

 * Events - Action handlers for UI cues and async operations

 * Refs - Are used as a handle to DOM elements such that they can be used to pull attributes and values

 * JSX - JS extension that allows javascript to accept markup and descriptor language to be embedded in code such that it can be parsed natively.

 ```js
export class Actionator extends React.Component {
    constructor(props){
        super(props);
        this.state = { message: "Resting..." };
    }

    takeAction(value: string) {
        this.state.setState(prevState => {...prevState, message: value});
    }

    public render() {
        const value = <h1>Display Me!</h1>;

        return <div>
            <div>{this.state.message}</div>
            <button onclick={takeAction(value)}>Action!</button>
        </div>;
    }
}
 ```

In the above example, the JavaScript engine can wholly understand the class declarations, methods, and properties.  It can also understand the presentation layer markup wire-up any events.

 * Enzyme - A JS Testing framework that works with React it is usually used in combination with Jasmine.  It allows for a suite of tests to be setup and run client-side to test the logic and processes of an application.
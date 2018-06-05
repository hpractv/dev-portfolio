 React

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

 * Events
    * Action handlers for UI queues

 * Refs - are used as a handle to DOM elements such that they can be used to pull attributes 

 * JSX
 * Enzyme
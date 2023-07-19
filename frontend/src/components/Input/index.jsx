import "./styles.css";
const Input = ({ label, ...props }) => {
  return (
    <div className="Input-Wrapper">
      <label className="LabelInput">{label}: </label>
      <input className="InputBox" {...props} />
    </div>
  );
};
export default Input;

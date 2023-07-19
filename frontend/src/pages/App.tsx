import { BrowserRouter } from "react-router-dom";
import AppRoutes from "../routes/index";
import { ThemeProvider, createTheme } from '@mui/material';
import * as colors from '@mui/material/colors';

const darkTheme = createTheme({
  palette: {
    mode: 'dark',
    primary: colors.green
  },
});

function App() {
  return (
    <ThemeProvider theme={darkTheme}>
      <BrowserRouter>
        <AppRoutes />
      </BrowserRouter>
    </ThemeProvider>
  );
}

export default App;

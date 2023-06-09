// import React, { useState } from 'react';

// import Toast from 'react-bootstrap/Toast';
// import Container from 'react-bootstrap/Container';
// import { Routes, Route, Outlet, Link } from "react-router-dom";
// import { AuthProvider } from 'oidc-react';

// import './App.css';


// const oidcConfig = {
//   onSignIn: () => {
//     // Redirect?
//   },
//   authority: 'https://localhost:5001',
//   clientId: 'webui',
//   redirectUri: 'http://localhost:3000/'
// };


// // const ExampleToast = ({ children }) => {
// //   const [show, toggleShow] = useState(true);

// //   return (
// //     <Toast show={show} onClose={() => toggleShow(!show)}>
// //       <Toast.Header>
// //         <strong className="mr-auto">React-Bootstrap</strong>
// //       </Toast.Header>
// //       <Toast.Body>{children}</Toast.Body>
// //     </Toast>
// //   );
// // };
// export default function App() {
//   return (
//     <div>
//       <h1>Basic Example</h1>

//       <p>
//         This example demonstrates some of the core features of React Router
//         including nested <code>&lt;Route&gt;</code>s,{" "}
//         <code>&lt;Outlet&gt;</code>s, <code>&lt;Link&gt;</code>s, and using a
//         "*" route (aka "splat route") to render a "not found" page when someone
//         visits an unrecognized URL.
//       </p>

//       {/* Routes nest inside one another. Nested route paths build upon
//             parent route paths, and nested route elements render inside
//             parent route elements. See the note about <Outlet> below. */}
//       <Routes>
//         <Route path="/" element={<Layout />}>
//           <Route index element={<Home />} />
//           <Route path="about" element={<About />} />
//           <Route path="dashboard" element={<Dashboard />} />

//           {/* Using path="*"" means "match anything", so this route
//                 acts like a catch-all for URLs that we don't have explicit
//                 routes for. */}
//           <Route path="*" element={<NoMatch />} />
//         </Route>
//       </Routes>
//     </div>
//   );
// }

// function Layout() {
//   return (
//     <div>
//       {/* A "layout route" is a good place to put markup you want to
//           share across all the pages on your site, like navigation. */}
//       <nav>
//         <ul>
//           <li>
//             <Link to="/">Home</Link>
//           </li>
//           <li>
//             <Link to="/about">About</Link>
//           </li>
//           <li>
//             <Link to="/dashboard">Dashboard</Link>
//           </li>
//           <li>
//             <Link to="/nothing-here">Nothing Here</Link>
//           </li>
//         </ul>
//       </nav>

//       <hr />

//       {/* An <Outlet> renders whatever child route is currently active,
//           so you can think about this <Outlet> as a placeholder for
//           the child routes we defined above. */}
//       <Outlet />
//     </div>
//   );
// }

// function Home() {
//   return (
//     <div>
//       <h2>Home</h2>
//     </div>
//   );
// }

// function About() {
//   return (
//     <div>
//       <h2>About</h2>
//     </div>
//   );
// }

// function Dashboard() {
//   return (
//     <div>
//       <h2>Dashboard</h2>
//     </div>
//   );
// }

// function NoMatch() {
//   return (
//     <div>
//       <h2>Nothing to see here!</h2>
//       <p>
//         <Link to="/">Go to the home page</Link>
//       </p>
//     </div>
//   );
// }



import React from 'react';
import { AuthProvider } from 'oidc-react';
import logo from './logo.svg';
import './App.css';

const oidcConfig = {
  onSignIn: async (user) => {
    alert('You just signed in, congratz! Check out the console!');
    console.log(user);
    window.location.hash = '';
  },
  authority: 'https://localhost:5001',
  clientId:
    'webui',
  responseType: 'code',
  redirectUri: 'http://localhost:3000/signin-oidc'
};

function App() {
  return (
    <AuthProvider {...oidcConfig}>
      <div className="App">
        <header className="App-header">
          <img src={logo} className="App-logo" alt="logo" />
          <p>OIDC React</p>
        </header>
      </div>
    </AuthProvider>
  );
}

export default App;